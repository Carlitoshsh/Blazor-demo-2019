using BlazorTest.Entities;
using BlazorTest.Entities.PokemonAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorTest.Business.API
{
    public class PokemonApi: BaseApiConsume 
    {
        public string apiUrl = "https://pokeapi.co/api/v2";
        public PokemonApi(IHttpClientFactory httpClientFactory): base(httpClientFactory) { }

        public async Task<PokemonProperties> GetPokemonProperties(string pokemonName) 
            => await ConsumirApi<PokemonProperties>($"{apiUrl}/pokemon/{pokemonName}", HttpMethod.Get);

        public async Task<GenerationResponse> GetPokemonGenerations() 
            => await ConsumirApi<GenerationResponse>($"{apiUrl}/generation", HttpMethod.Get);

        public async Task<GenerationProperties> GetPokemonsByGenerations(string generationUrl) 
            => await ConsumirApi<GenerationProperties>(generationUrl, HttpMethod.Get);
    }
}
