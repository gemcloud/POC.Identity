using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System;
using System.IO;
//using Poc.GlobalErrorHandling.Serilog.Extensions;

namespace Poc.GlobalErrorHandling.Serilog
{
    public class Program
    {

        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                           .AddJsonFile("appsettings.serilogs.json", optional: false, reloadOnChange: true)   // Read Serilog Configuration.
                           .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                           .AddJsonFile($"appsettings.{Environment.MachineName}.json", optional: true)
                           .AddEnvironmentVariables()
                           .Build();


        public static void Main(string[] args)
        {
            //// Console.log
            //Log.Logger = new LoggerConfiguration()
            //                .Enrich.FromLogContext()
            //                .WriteTo.Console()
            //                .CreateLogger();

            //// JSon
            //Log.Logger = new LoggerConfiguration()
            //                .Enrich.FromLogContext()
            //                .WriteTo.Console(new RenderedCompactJsonFormatter())
            //                .CreateLogger();

            Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)    // Turn off Information events from Microsoft and System
                    .MinimumLevel.Override("System", LogEventLevel.Warning)
                    .ReadFrom.Configuration(Configuration)
                    .CreateLogger();

            try
            {
                Log.Information("Starting web host");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                //.UseSerilog()    // Add Serilog
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseSerilog();    // Add Serilog;
    }
}
