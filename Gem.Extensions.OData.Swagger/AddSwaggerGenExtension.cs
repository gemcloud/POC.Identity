using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace Gem.Extensions.OData.Swagger
{
    public static class AddSwaggerGenExtension
    {
        /// <summary>
        /// JwtBearer Authentication Swagger
        /// </summary>
        /// <param name="services"></param>
        public static void AddODataSwaggerGenJwt(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Poc OData API", Version = "v1" });
                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, //Name the security scheme
                    new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme.",
                        Type = SecuritySchemeType.Http, //We set the scheme type to http since we're using bearer authentication
                        Scheme = "bearer"               //The name of the HTTP Authorization scheme to be used in the Authorization header. In this case "bearer".
                    });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                        {
                            new OpenApiSecurityScheme {
                                Reference = new OpenApiReference{
                                    Id = JwtBearerDefaults.AuthenticationScheme,      //The name of the previously defined security scheme.
                                    Type = ReferenceType.SecurityScheme
                                }
                            },
                            new List<string>()
                        }
                    });
                c.OperationFilter<AddParamOperationFilter>();
                c.EnableAnnotations();
            });
        }

        /// <summary>
        /// Not Authentication, Basic Swagger
        /// </summary>
        /// <param name="services"></param>
        public static void AddODataSwaggerGenNormal(this IServiceCollection services)
        {
            services.AddSwaggerGen((config) =>
            {
                config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Swagger Odata Demo Api",
                    Description = "Swagger Odata Demo",
                    Version = "v1"
                });
            });
        }

    }
}
