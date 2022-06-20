using Contracts;
using Entities;
using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyEmployees.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureCors(this IServiceCollection services) =>
                                         services.AddCors(options =>
        {
             options.AddPolicy("CorsPolicy", builder =>
             builder.WithOrigins("https://example.com")
             .WithMethods("POST", "GET")
             .WithHeaders("accept", "content-type"));
        });

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
                                                   services.Configure<IISOptions>(options =>
                   {
                   });
        public static void ConfigureLoggerService(this IServiceCollection services) =>
                           services.AddScoped<ILoggerManager, LoggerManager>();

        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration) =>
                services.AddDbContext<RepositoryContext>(opts =>
                    opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b =>
                    b.MigrationsAssembly("CompanyEmployees")));
    }
}
