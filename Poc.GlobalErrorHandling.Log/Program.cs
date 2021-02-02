using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;

namespace Poc.GlobalErrorHandling.Log
{
    public class Program
    {

        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                           .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                           .AddJsonFile($"appsettings.{Environment.MachineName}.json", optional: true)
                           .AddEnvironmentVariables()
                           .Build();


        public static void Main(string[] args)
        {
            //// Console.log
            //Serilog.Log.Logger = new LoggerConfiguration()
            //                .Enrich.FromLogContext()
            //                .WriteTo.Console()
            //                .CreateLogger();

            //// JSon
            //Serilog.Log.Logger = new LoggerConfiguration()
            //                .Enrich.FromLogContext()
            //                .WriteTo.Console(new RenderedCompactJsonFormatter())
            //                .CreateLogger();

            Serilog.Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .CreateLogger();

            try
            {
                Serilog.Log.Information("Starting web host");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Serilog.Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Serilog.Log.CloseAndFlush();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()    // Add Serilog
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
