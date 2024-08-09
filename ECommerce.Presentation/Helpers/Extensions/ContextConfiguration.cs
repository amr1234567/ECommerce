using ECommerce.Core.Helpers.Classes;
using ECommerce.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Presentation.Helpers.Extensions
{
    public static class ContextConfiguration
    {
        public static IServiceCollection AddContextDi(this IServiceCollection services, IConfiguration configuration)
        {
            var mongoOptions = configuration.GetSection("MongoDBSettings").Get<MongoOptions>();

            services.AddDbContext<ECommerceContext>(options =>
                {
                    options.UseMongoDB(mongoOptions.ConnectionString, mongoOptions.DB);
                });

            return services;
        }
    }
}
