using ECommerce.Core.Entities.Users;
using ECommerce.DataAccess.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Presentation.Helpers.Extensions
{
    public static class IdentityConfiguration
    {
        public static IServiceCollection AddIdentityConfig(this IServiceCollection services)
        {
            services.AddIdentityCore<User>(options => { })
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<ECommerceContext>()
                    .AddDefaultTokenProviders();


            //ConfigureIdentity<Consumer>(services);
            //ConfigureIdentity<Admin>(services);
            //ConfigureIdentity<User>(services);
            //ConfigureIdentity<Delivery>(services);

            return services;
        }

        //private static void ConfigureIdentity<TUser>(IServiceCollection services) where TUser : User
        //{
        //    if (typeof(TUser) == typeof(User))
        //    {
        //        // Use AddIdentity for one of your user types (e.g., Consumer)
        //        services.AddIdentity<Consumer, IdentityRole>(options => { })
        //            .AddEntityFrameworkStores<ECommerceContext>()
        //            .AddDefaultTokenProviders();
        //    }
        //    else
        //    {
        //        // Use AddIdentityCore for the rest
        //        services.AddIdentityCore<TUser>(options => { })
        //            .AddRoles<IdentityRole>()
        //            .AddEntityFrameworkStores<ECommerceContext>()
        //            .AddDefaultTokenProviders();
        //    }
        //}

    }
}
