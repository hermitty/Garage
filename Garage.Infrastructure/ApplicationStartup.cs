using Garage.Domain.Interface;
using Garage.Infrastructure.Configuration;
using Garage.Infrastructure.DataAccess;
using Garage.Infrastructure.Repository;
using Garage.Infrastructure.Service;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

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

            ////var appSettings = appSettingsSection.Get<AppSettings>();
            //var key = Encoding.ASCII.GetBytes("THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING");
            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(x =>
            //{
            //    x.RequireHttpsMetadata = false;
            //    x.SaveToken = true;
            //    x.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = false,
            //        ValidateAudience = false
            //    };
            //});
            // ===== Add Jwt Authentication ========
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
                                                                        // jwt
                                                                        // get options
           // var jwtAppSettingOptions = Configuration.GetSection("JwtIssuerOptions");
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                       // ValidIssuer = jwtAppSettingOptions["JwtIssuer"],
                        //ValidAudience = jwtAppSettingOptions["JwtIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING")),
                        ClockSkew = TimeSpan.Zero // remove delay of token when expire
        };
                });
            services.AddScoped(typeof(IIdentityService), typeof(IdentityService));
        }
    }
}
