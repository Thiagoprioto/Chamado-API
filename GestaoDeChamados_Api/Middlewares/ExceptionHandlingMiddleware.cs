using System.Net;
using System.Text.Json;

namespace Chamados.Api.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu uma exceção não tratada: {Message}", ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var (statusCode, message) = exception switch
        {
            // Erro de Regra de Negócio (ex: alterar chamado cancelado) -> 400 Bad Request
            InvalidOperationException or ArgumentException => (HttpStatusCode.BadRequest, exception.Message),

            // Recurso não encontrado -> 404 Not Found
            KeyNotFoundException => (HttpStatusCode.NotFound, exception.Message),

            // Qualquer outro erro não esperado -> 500 Internal Server Error
            _ => (HttpStatusCode.InternalServerError, "Ocorreu um erro interno no servidor.")
        };

        context.Response.StatusCode = (int)statusCode;

        var response = new
        {
            status = context.Response.StatusCode,
            error = statusCode.ToString(),
            message = message,
            timestamp = DateTime.UtcNow
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}