using Gem.Extensions.OData.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Poc.GlobalErrorHandling.Serilog.Extensions;
using Poc.GlobalErrorHandling.Serilog.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using ILogger = Serilog.ILogger;

namespace Poc.GlobalErrorHandling.Serilog
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // ==== ## register AddSwaggerGen ===============>
            services.AddODataSwaggerGenNormal();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) //, ILogger seriLogger) 
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // ==== ## SerilogMiddleware. ===============>
            app.UseMiddleware<SerilogMiddleware>();

            // ==== ## Use built-in Middleware app.UseExceptionHandler. ===============>
            //app.ConfigureExceptionHandler(seriLogger);
            // ==== ## Use Custom Exception Middleware. ===============>
            app.ConfigureCustomExceptionMiddleware();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            // ==== ## use AddSwaggerGen ===============>
            app.UseSwaggerDocumentation("Poc.GlobalErrorHandling.Serilog V1.0");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
