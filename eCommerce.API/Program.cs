using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add Infrastructure services to the container.
builder.Services.AddInfrastructure();
builder.Services.AddCore();

// Add controllers to the container
builder.Services.AddControllers();
var app = builder.Build();

app.UseExceptionHandlingMiddleware();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Controller Routes
app.MapControllers();

app.Run();