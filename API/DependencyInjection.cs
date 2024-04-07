using API.Mappings;
using System.Runtime.CompilerServices;

namespace API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation( this IServiceCollection services)
        {
            services.AddControllers();
            services.AddMappings();
            
            return services;
        }
    }
}
