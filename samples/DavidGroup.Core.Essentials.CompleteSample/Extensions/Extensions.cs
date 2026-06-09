using DavidGroup.Core.Essentials.CompleteSample.Repositories;
using DavidGroup.Core.Essentials.CompleteSample.Services;

namespace DavidGroup.Core.Essentials.CompleteSample.Extensions;

public static class Extensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddRepositories()
        {
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IManufacturersRepository, ManufacturersRepository>();

            return services;
        }

        public IServiceCollection AddServices()
        {
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IManufacturersService, ManufacturersService>();

            return services;
        }
    }
}