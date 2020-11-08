using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BlazorTest.Helpers
{
    public class ErrorsHandler
    {
        private readonly RequestDelegate siguiente;
        public ErrorsHandler(RequestDelegate siguiente)
        {
            this.siguiente = siguiente;
        }

        public async Task Invoke(HttpContext contexto)
        {
            try
            {
                await siguiente(contexto);
            }
            catch (Exception ex)
            {
                await ManejadorAsincronoErrores(contexto, ex);
            }
        }

        private static Task ManejadorAsincronoErrores(HttpContext contexto, Exception ex)
        {
            var codigo = HttpStatusCode.InternalServerError; // 500 if unexpected

            var result = JsonSerializer.Serialize(new
            {
                error = ex.Message,
                stacktrace = ex.StackTrace,
                innerexception = ex.InnerException
            });
            contexto.Response.ContentType = "application/json";
            contexto.Response.StatusCode = (int)codigo;
            return contexto.Response.WriteAsync(result);
        }
    }
}