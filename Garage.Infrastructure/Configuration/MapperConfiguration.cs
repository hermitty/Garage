using AutoMapper;
using Garage.Application.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace Garage.Infrastructure.Configuration
{
    public static class MapperConfiguration
    {
        public static void ConfigureMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CustomerMapper));
            services.AddAutoMapper(typeof(CustomerMapper));
            services.AddAutoMapper(typeof(JobMapper));
        }
    }
}
