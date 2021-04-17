using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokeApi.Models;

namespace PokeApi.Controllers
{
    [ApiController]
    [Route("/api/pokemon")]
    public class PokemonController : ControllerBase
    {
        private readonly IHttpClientFactory clientFactory;

        public PokemonController(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }
        [HttpGet]
        public async Task<IEnumerable<Pokemon>> GetPokemons()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://pokeapi.co/api/v2/pokemon/");
            var client = clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                
            }
        }
    }
}