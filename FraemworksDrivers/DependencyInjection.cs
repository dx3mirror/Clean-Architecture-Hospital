using FraemworksDrivers.Cache;
using FraemworksDrivers.Mapping;
using Microsoft.Extensions.DependencyInjection;


namespace FraemworksDrivers
{
    public class DependencyInjection
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
