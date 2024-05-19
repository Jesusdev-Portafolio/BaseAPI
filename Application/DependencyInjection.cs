using Application.Common.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Filters;
using System.Reflection;


namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, WebApplicationBuilder builder)
        {
            ConfigureSerilog(builder);

            services.AddSerilog();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }

        private static void ConfigureSerilog(WebApplicationBuilder builder)
        {
            var configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
                   .Build();

            Log.Logger = new LoggerConfiguration()
                 .WriteTo.Debug()
                 .Enrich.FromLogContext()
                 .Filter.ByExcluding(Matching.FromSource<Microsoft.AspNetCore.Diagnostics.ExceptionHandlerMiddleware>())
                 //.ReadFrom.Configuration(configuration) //no consigo hacer que funcione desde aqui
                 .CreateLogger();

            builder.Host.UseSerilog();
        }
    }
}
