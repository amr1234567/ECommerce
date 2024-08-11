using ECommerce.Core.Repositories.Manager;
using ECommerce.DataAccess.Repositories.Manager;
using ECommerce.Repository.Abstraction.UnitOfWork;
using ECommerce.Repository.Services.UnitOfWork;
using ECommerce.Repository.Abstraction;
using ECommerce.Repository.Services;

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
