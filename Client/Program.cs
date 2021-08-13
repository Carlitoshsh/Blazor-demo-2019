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
            AddServices(builder);

            builder.Services.AddHttpClient("configured-inner-handler", c =>
            {
                c.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
            });

            await builder.Build().RunAsync();
        }

        private static void AddServices(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddSingleton<BaseApiConsume>();
            builder.Services.AddSingleton<PokemonApi>();
            builder.Services.AddSingleton<SiteApi>();
        }
    }
}
