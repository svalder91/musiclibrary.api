using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;

namespace Demo.MusicLibrary.Api.Core.Infrastructure.Middlewares
{
    public class CorrelationIdMiddleware
    {
        private readonly ILogger<CorrelationIdMiddleware> _logger;
        private readonly RequestDelegate _next;

        public CorrelationIdMiddleware(ILogger<CorrelationIdMiddleware> logger, RequestDelegate next)
        {
            this._logger = logger;
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Items["CorrelationId"] = Guid.NewGuid().ToString("N");
            _logger.LogInformation($"About to start {context.Request.Method} {context.Request.GetDisplayUrl()} request");

            await _next(context);

            _logger.LogInformation($"Request completed with status code: {context.Response.StatusCode} ");
        }
    }   
}
