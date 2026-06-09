using DavidGroup.Core.Essentials.CompleteSample.Repositories;
using DavidGroup.Core.Essentials.CompleteSample.Services;

namespace DavidGroup.Core.Essentials.CompleteSample.Extensions;

public static class Extensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProductsRepository, ProductsRepository>();
        services.AddScoped<IManufacturersRepository, ManufacturersRepository>();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IProductsService, ProductsService>();
        services.AddScoped<IManufacturersService, ManufacturersService>();

        return services;
    }
}