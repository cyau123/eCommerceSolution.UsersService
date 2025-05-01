using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;


public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add infrastructure services to the independency injection container
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // TODO: Add service to the IoC container
        // Infrastructure services include data access, caching, logging, and other low-level components

        services.AddSingleton<IUsersRepository, UsersRepository>();
        return services;
    }
}