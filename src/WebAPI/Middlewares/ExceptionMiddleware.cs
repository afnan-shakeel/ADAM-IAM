using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Exceptions;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            _logger.LogInformation($"Handling request: {context.Request.Method} {context.Request.Path}");

            context.Request.EnableBuffering();
            var bodyAsText = await new StreamReader(context.Request.Body).ReadToEndAsync();
            context.Request.Body.Position = 0;

            _logger.LogInformation($"Request Body: {bodyAsText}");
            await _next(context); // Continue down the pipeline
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error occurred: ");
            await HandleExceptionAsync(context, ex); // Handle exceptions globally
        }
    }
    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var statusCode = HttpStatusCode.InternalServerError;
        var message = "An unexpected error occurred.";

        if (exception is NotFoundException)
        {
            statusCode = HttpStatusCode.NotFound;
            message = exception.Message;
        }
        else if (exception is ValidationException validationException)
        {
            statusCode = HttpStatusCode.BadRequest;
            message = validationException.Message;
            var validationErrors = validationException.ValidationErrors;

            // Optionally include detailed validation errors in the response
        }
        // else if (exception is BusinessException)
        // {
        //     statusCode = HttpStatusCode.UnprocessableEntity;
        //     message = exception.Message;
        // }
        else
        {
            statusCode = HttpStatusCode.UnprocessableEntity;
            message = exception.Message;
        }

        var response = new
        {
            StatusCode = (int)statusCode,
            Message = message
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;
        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
