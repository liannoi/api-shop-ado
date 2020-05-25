using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopAdo.System.Core.Application.Common.Interfaces;
using ShopAdo.System.Infrastructure.Persistence;

namespace ShopAdo.System.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ShopAdoContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ShopAdoContext")));

            services.AddScoped<IShopAdoContext>(provider => provider.GetService<ShopAdoContext>());

            return services;
        }
    }
}