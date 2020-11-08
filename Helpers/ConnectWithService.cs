using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using BlazorTest.Entities.Helpers;

namespace BlazorTest.Helpers
{

    public class ConnectWithService
    {
        private readonly IHttpClientFactory _clientFactory;
        public string Respuesta { get; private set; }
        public ConnectWithService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task ComunicarseConServicio(HttpRequestMessage elRequest, string token = "")
        {
            try
            {
                HttpClient client = _clientFactory.CreateClient("configured-inner-handler");
                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                var response = await client.SendAsync(elRequest);
                if (response.IsSuccessStatusCode)
                {
                    Respuesta = await response.Content
                        .ReadAsStringAsync();
                }
                else
                {
                    Respuesta = JsonSerializer.Serialize(
                    new ErrorMessage
                    {
                        Error = true,
                        Mensaje = "Error",
                    }
                   );
                }
                client.Dispose();
            }
            catch (Exception e)
            {
                Respuesta = JsonSerializer.Serialize(new ErrorMessage
                {
                    Error = true,
                    Mensaje = "Error",
                    Excepcion = e.Message,
                    InnerException = e.InnerException.ToString()
                });
            }
        }

        public async Task<T> ConstruirMetodo<T>(string metodo, HttpMethod httpMethod, string json, string token)
        {
            HttpRequestMessage request = new HttpRequestMessage(httpMethod, metodo);
            if (!string.IsNullOrEmpty(json))
            {
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }
            await ComunicarseConServicio(request, token);
            return JsonSerializer.Deserialize<T>(Respuesta);
        }
    }
}
