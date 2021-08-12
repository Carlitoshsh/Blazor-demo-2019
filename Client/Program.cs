using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BlazorTest.Client.API;

namespace BlazorTest.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            // Singletons
            builder.Services.AddSingleton<BaseApiConsume>();
            builder.Services.AddSingleton<PokemonApi>();

            builder.Services.AddHttpClient("configured-inner-handler");

            await builder.Build().RunAsync();
        }
    }
}
