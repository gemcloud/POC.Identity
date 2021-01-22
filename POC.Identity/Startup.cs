using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using POC.Identity.Infrastructure;
using POC.Identity.Infrastructure.Entities.AspNetIdentity;

namespace POC.Identity
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
            //--------------------------------------
            // Add DBContext here! or on OnConfiguring()!
            // SQl Server
            services.AddDbContext<PocApplicationDbContext>(options =>
                        options.UseSqlServer(Configuration["ConnectionStrings:SqlServerContextConnection"]));


            //--------------------------------------
            // Add Identity tables relationship. DI 
            services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.Stores.MaxLengthForKeys = 128)
            .AddEntityFrameworkStores<PocApplicationDbContext>()
            .AddDefaultTokenProviders();

            services.AddControllersWithViews();

            //--------------------------------------
            // ADDED : by VGuan.
            services.AddMemoryCache();
            services.AddSession();      //#### Register AddSession()
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //-----------------------------------------------------
            // Added by VGuan
            app.UseSession();       //#### call UseSession()

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
