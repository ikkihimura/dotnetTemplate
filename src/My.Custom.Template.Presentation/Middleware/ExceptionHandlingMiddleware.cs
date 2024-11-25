using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using My.Custom.Template.Domain.Models;
using My.Custom.Template.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace My.Custom.Template.Presentation.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _log;
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _log = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, _log);
            }

        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception, ILogger logger)
        {
            if (exception == null) return;

            await WriteExceptionAsync(context, exception, logger);

        }

        private static async Task WriteExceptionAsync(HttpContext context, Exception exception, ILogger logger)
        {
            var response = context.Response;

            response.ContentType = "application/json";
            response.StatusCode = (int)ResponseCodes.Failure;

            if (exception is AggregateException aggregateException)
            {
                exception = aggregateException.Flatten();
            }

            await response.WriteAsync(JsonSerializer.Serialize(new ErrorResponse
            {
                Code = response.StatusCode,
                Description = ResponseCodes.FailureResponse,
                Data = null,
                Error = new DataError { Message = exception.Message, Code = exception.GetHashCode() }
            })).ConfigureAwait(false);

            var request = (context.Request?.Path ?? "") + (context.Request?.QueryString.ToString() ?? "");
            logger.LogError($"Failed request {request} Error:{exception.Message}");
        }
    }
}
