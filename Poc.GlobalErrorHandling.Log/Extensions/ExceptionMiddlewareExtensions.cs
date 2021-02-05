using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Poc.GlobalErrorHandling.Serilog.Middleware;
using Poc.GlobalErrorHandling.Serilog.Models;
using Serilog;
using System.Net;
using ILogger = Serilog.ILogger;

namespace Poc.GlobalErrorHandling.Serilog.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        /// <summary>
        /// Custom Middleware Used.
        /// </summary>
        /// <param name="app"></param>
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }

        /// <summary>
        /// The UseExceptionHandler middleware is a built-in middleware
        /// </summary>
        /// <param name="app"></param>
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger seriLogger) //, ILoggerManager logger)
        {
            // built-in middleware
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        //LogError($"Something went wrong: {contextFeature.Error}");
                        seriLogger.Information($"Something went wrong: {contextFeature.Error}");

                        await context.Response.WriteAsync(new ErrorDetailModel()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Middleware says: Internal Server Error. "
                        }.ToString());
                    }
                });
            });
        }

    }
}
