using Rd.Veiculos.Api.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Rd.Veiculos.Api.Middlewares;

[ExcludeFromCodeCoverage]
public class ExceptionMiddleware
{
    const string DEFAULT_EXCEPTION = "Ocorreu um erro inesperado.";
    const string CANCELED_EXCEPTION = "A solicitacao foi cancelada.";
    const string VALIDATION_EXCEPTION = "Ocorreu um erro ao validar os valores de entrada";

    readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ILogger<ExceptionMiddleware> logger)
    {
        try
        {
            context.Request.EnableBuffering();
            await _next(context);
        }
        catch (Exception exception)
        {
            switch (exception)
            {
                case OperationCanceledException:
                    await HandlingExceptionAsync(logger, context, StatusCodes.Status400BadRequest, CANCELED_EXCEPTION);
                    break;

                case ValidationException ex:
                    await HandlingExceptionAsync(logger, context, StatusCodes.Status422UnprocessableEntity, VALIDATION_EXCEPTION, ex);
                    break;

                default:
                    await HandlingExceptionAsync(logger, context, StatusCodes.Status500InternalServerError, DEFAULT_EXCEPTION, exception);
                    break;
            }
        }
    }

    private static Task HandlingExceptionAsync(ILogger<ExceptionMiddleware> logger,
        HttpContext context,
        int statusCodes,
        string error,
        Exception? exception = default
        )
    {
        logger.LogError($"Encountered a issue. error: {error}", exception);

        context.Response.StatusCode = statusCodes;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsJsonAsync(new ErrorModel(statusCodes, error));
    }

    private static Task HandlingExceptionAsync(ILogger<ExceptionMiddleware> logger,
        HttpContext context,
        int statusCodes,
        string error,
        ValidationException exception
        )
    {
        logger.LogError($"Encountered a issue. error: {error}", exception);

        context.Response.StatusCode = statusCodes;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsJsonAsync(new ErrorModel(statusCodes, error, new Dictionary<string, string[]>
        {
            [string.Empty] = new[] { exception.Message }
        }));
    }
}
