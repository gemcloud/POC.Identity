using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gem.Extensions.OData.Swagger;
using MediatR;

namespace Poc.OData.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //var config = new ApiConfig();
            //configuration.GetSection("Api").Bind(config);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // ==== Approach #1: DI  ApiConfig by services.AddSingleton<ApiConfig>(configApi);
            ////add api configuration parameters
            //var configApi = new ApiConfig();
            //Configuration.GetSection("Api").Bind(configApi);
            ////Create singleton from instance
            //services.AddSingleton<ApiConfig>(configApi);

            // ==== Approach #2: use services.Configure<ApiConfig> + IOptions<ApiConfig> apiConfig  ===========>
            services.Configure<ApiConfig>(Configuration.GetSection("Api"));

            // ==== ## Add AddNewtonsoftJson() ==== Not Must be! ===========>
            services.AddControllers(); //.AddNewtonsoftJson();

            // ==== #1 Add AddOData() & AddODataQueryFilter() ===============>
            services.AddOData();
            services.AddODataQueryFilter();

            // ==== #2A AddSwaggerGen ===============>
            //services.AddODataSwaggerGenNormal();
            // ==== #2B AddSwaggerGen With AuthenticationScheme ===============>
            services.AddODataSwaggerGenJwt();
            // ==== #3 Add  AddOdataSwaggerOutputFormatters by Extension Class (Reuseful) ===============>
            services.AddOdataSwaggerOutputFormatters();

            //==== AddMediatR ===============>
            services.AddMediatR(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //// ==== #1 Add UseSwagger UI ===========>
            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Poc OData API V1");
            //});
            app.UseSwaggerDocumentation("Poc OData API V2.0");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                // ==== #2 Add EnableDependencyInjection ===========>
                endpoints.EnableDependencyInjection();
                //// ==== #3 Add Select().Filter().OrderBy().Count().MaxTop(10) ===========>
                endpoints.Select().Filter().OrderBy().Count().MaxTop(10);
            });
        }


        //private static void AddMediator(this IServiceCollection services)
        //{
        //    //var typeFinder = new WebAppTypeFinder();
        //    //var assemblies = typeFinder.GetAssemblies();
        //    services.AddMediatR(assemblies.ToArray());
        //}
    }
}
