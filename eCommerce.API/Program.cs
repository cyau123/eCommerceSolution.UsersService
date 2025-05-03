using System.Text.Json.Serialization;
using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add Infrastructure services to the container.
builder.Services.AddInfrastructure();
builder.Services.AddCore();

// Add controllers to the container
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Scan all mapping profiles in the assembly
builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);

// Add FluentValidation
builder.Services.AddFluentValidationAutoValidation();

// Add API Explorer Services
builder.Services.AddEndpointsApiExplorer();

// Add Swagger Generation to create Swagger specification
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => builder.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod());
});

var app = builder.Build();

app.UseExceptionHandlingMiddleware();
app.UseRouting();

// Add endpoints that serve the generated Swagger specification
app.UseSwagger();
// Use Swagger UI to visualize and test the API
app.UseSwaggerUI();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

// Controller Routes
app.MapControllers();

app.Run();