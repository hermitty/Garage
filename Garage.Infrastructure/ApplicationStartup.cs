using Garage.Domain.Interface;
using Garage.Infrastructure.Configurations;
using Garage.Infrastructure.DataAccess;
using Garage.Infrastructure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Garage.Infrastructure
{
    public class ApplicationStartup
    {
        public static void Initialize(IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            services.ConfigureMapper();
            services.AddDbContext<Context>
                (item => item.UseSqlServer(configuration.GetConnectionString("connectionString")));

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            var assembly = AppDomain.CurrentDomain.Load("Garage.Application");
            services.AddMediatR(assembly);
        }
    }
}
