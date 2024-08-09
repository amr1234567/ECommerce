using ECommerce.Core.Repositories.Manager;
using ECommerce.DataAccess.Repositories.Manager;
using ECommerce.Repositry.Abstraction.UnitOfWork;
using ECommerce.Repositry.Abstraction;
using ECommerce.Repositry.Services;

namespace ECommerce.Presentation.Helpers.Extensions
{
    public static class ScopesConfiguration
    {
        public static IServiceCollection AddScopesForServices(this IServiceCollection services)
        {
            services.AddScoped<IManagerRepository, ManagerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<ITokenServices, TokenServices>();
            return services;
        }
    }
}
