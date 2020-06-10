using Garage.Domain.Interface;
using Garage.Infrastructure.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Infrastructure
{
    public class ApplicationStartup
    {
        public static void Initialize(IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            
            
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            var assembly = AppDomain.CurrentDomain.Load("Garage.Application");
            services.AddMediatR(assembly);
        }
    }
}
