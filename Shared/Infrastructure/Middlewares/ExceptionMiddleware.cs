
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shared.Abstractions.Exceptions;

namespace Shared.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;
        private readonly IHostEnvironment env;

        public ExceptionMiddleware(RequestDelegate _next,ILogger<ExceptionMiddleware> logger,IHostEnvironment env)
        {
            this.next = _next;
            this.logger = logger;
            this.env = env;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                logger.LogWarning(ex.Message);
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = env.IsDevelopment() ? new ApiException(httpContext.Response.StatusCode, ex.Message, ex.StackTrace.ToString()) :
                        new ApiResponse(httpContext.Response.StatusCode);

                var json = JsonSerializer.Serialize(response,new JsonSerializerOptions {PropertyNamingPolicy=JsonNamingPolicy.CamelCase });
                
                await httpContext.Response.WriteAsync(json);

            }
        }
    }
}
