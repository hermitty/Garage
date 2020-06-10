using AutoMapper;
using Garage.DB.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace Garage.HostApi.Configurations
{
    public static class MapperConfiguration
    {
        public static void ConfigureMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CustomerMapper));
        }
    }
}
