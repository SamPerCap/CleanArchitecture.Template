using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Domain.Entities.UserEntity;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Sinks.PostgreSQL;

namespace Infrastructure.Data.Configuration
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration config)
        {
            ConfigureLogging(config);
            services.AddDatabase(config);
            services.AddIdentityServices();
            services.AddDependencyInjection(config);
            services.AddScoped<ApplicationDbContextInitialiser>();

            return services;
        }

        private static void ConfigureLogging(IConfiguration config)
        {
            // Get PostgreSQL connection string from config
            var connectionString = config.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string 'DefaultConnection' not found.");

            // Serilog configuration
            Log.Logger = new LoggerConfiguration()
                .WriteTo.PostgreSQL
                (
                    connectionString,
                    tableName: "Logs"
                )
                .MinimumLevel.Warning()
                .Enrich.FromLogContext()
                .CreateLogger();

            // Ensure logs are flushed on application shutdown
            AppDomain.CurrentDomain.ProcessExit += (s, e) => Log.CloseAndFlush();
        }

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration config)
        {
            var rawConnectionString = config.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string 'DefaultConnection' not found.");

            var connectionString = BuildConnectionString(rawConnectionString);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));

            return services;
        }

        private static string BuildConnectionString(string rawConnectionString)
        {
            var connectionString = rawConnectionString
                .Replace("__USER__", Environment.GetEnvironmentVariable("POSTGRES_USER") ?? throw new Exception("POSTGRES_USER missing"))
                .Replace("__PASS__", Environment.GetEnvironmentVariable("POSTGRES_PASSWORD") ?? throw new Exception("POSTGRES_PASSWORD missing"))
                .Replace("__DB__", Environment.GetEnvironmentVariable("POSTGRES_DB") ?? throw new Exception("POSTGRES_DB missing"));

            return connectionString;
        }

        private static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }

        private static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration config)
        {
            services.AddHttpContextAccessor();

            // Singleton services

            // Scoped services
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}