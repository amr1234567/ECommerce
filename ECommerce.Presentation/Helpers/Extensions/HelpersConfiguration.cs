using ECommerce.Core.Helpers.Classes;
using ECommerce.Core.Helpers.Enums;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;

namespace ECommerce.Presentation.Helpers.Extensions
{
    public static class HelpersConfiguration
    {
        public static IServiceCollection AddHelpersConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtHelper>(configuration.GetSection("Jwt"));

            BsonSerializer.RegisterSerializer(new EnumSerializer<TransactionStatus>(BsonType.String));
            BsonSerializer.RegisterSerializer(new EnumSerializer<SellerTypes>(BsonType.String));
            BsonSerializer.RegisterSerializer(new EnumSerializer<BugReportStatus>(BsonType.String));
            BsonSerializer.RegisterSerializer(new EnumSerializer<UserRoles>(BsonType.String));
            return services;
        }
    }
}
