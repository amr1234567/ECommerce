using ECommerce.Presentation.Helpers.Extensions;
using ECommerce.Presentation.Helpers.Filters;

namespace ECommerce.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(o =>
            {
                o.Filters.Add<PaginationFilter>();
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddContextDi(builder.Configuration);
            builder.Services.AddIdentityConfig();
            builder.Services.AddSwaggerConfig();
            builder.Services.AddHelpersConfig(builder.Configuration);
            builder.Services.AddAuthConfig(builder.Configuration);
            builder.Services.AddScopesForServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCustomMiddlewares();

            app.MapControllers();

            app.Run();
        }

    }
}
