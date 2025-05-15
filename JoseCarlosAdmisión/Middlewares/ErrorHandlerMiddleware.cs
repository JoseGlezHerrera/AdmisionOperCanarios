using JoseCarlos.Application.Exceptions;
using JoseCarlos.Application.Wrappers;
using System.Net;
using System.Text.Json;
namespace JoseCarlosAdmisión.Middlewares
/// <summary>
/// Este middleware se encarga de capturar errores globales, registrarlos y enviar una respuesta al json evitando
/// que le lleguen al cliente de forma no controlada.
/// </summary>
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogger<ErrorHandlerMiddleware> _logger;
        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            this._next = next;
            this._logger = logger;
        }
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        private async Task HandleExceptionMensaggeAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            var responseModel = new JoseCarlos.Application.Wrappers.Response<string>()
            {
                succeeded = false,
                message = exception?.Message,
                data = exception.StackTrace
            };

            switch (exception)
            {
                case ArgumentException:
                case ArgumentInputException:
                case UserNullException:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    responseModel.data = "";
                    break;
                case KeyNotFoundException:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            var result = JsonSerializer.Serialize(responseModel);
            await response.WriteAsync(result);
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                this._logger.LogError(error, "Error en la aplicación");
                await this.HandleExceptionMensaggeAsync(context, error).ConfigureAwait(false);
                //Logea el error.
            }
        }
    }
}
