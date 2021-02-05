using Microsoft.AspNetCore.Http;
using Poc.GlobalErrorHandling.Serilog.Models;
using System;
using System.Net;
using System.Threading.Tasks;
using Serilog;
using Microsoft.Extensions.Logging;
//using ILogger = Serilog.ILogger;

namespace Poc.GlobalErrorHandling.Serilog.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly ILoggerManager _logger;
        private readonly ILogger<ExceptionMiddleware> _logger;
        //private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next , ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ExceptionMiddleware says: Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            _logger.LogWarning("Gem Cloud: HandleExceptionAsync");

            return context.Response.WriteAsync(new ErrorDetailModel()
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error from the custom middleware."
            }.ToString());
        }
    }
}
