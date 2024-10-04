using _2_ApplicationLayer.Exceptions;
using System.Net;
using System.Text.Json;

namespace _4_FrameworksDrivers_API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private static async Task HandleExceptionAsync(HttpContext context, ValidationException exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var statusCode = HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(new
            {
                error = exception.Message,
                detail = exception.InnerException?.Message
            });

            response.StatusCode = (int)statusCode;
            await response.WriteAsync(result);
        }

    }
}
