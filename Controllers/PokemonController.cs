using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PokeApi.Models;

namespace PokeApi.Controllers
{
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private static readonly HttpClient client = new HttpClient();
        private IEnumerable<Pokemon> pokemons;
        private string errorString;

        public PokemonController()
        {
            this.pokemons = new List<Pokemon>();
        }

        [Route("/api/pokemon")]

        public async Task<string> GetPokemon()
        {
            string baseUrl = "http://pokeapi.co/api/v2/pokemon?limit=2000";
            try
            {
                var response = await client.GetAsync(baseUrl);
                var content = response.Content;
                var data = await content.ReadAsStringAsync();
                if (content != null)
                {
                    var pokemons = JObject.Parse(data)["results"].ToString();
                    return pokemons;
                }
                else
                {
                    errorString = "Loading...";
                    return errorString;
                }
            }
            catch (Exception ex)
            {
                errorString = $"Error: {ex}";
                return errorString;
            }
        }

        [HttpGet("/api/pokemon/{id:int}")]
        public async Task<string> GetOnePokemon(int id)
        {
            string baseURL = $"http://pokeapi.co/api/v2/pokemon/{id}/";
            try
            {
                var response = await client.GetAsync(baseURL);
                var content = response.Content;
                var data = await content.ReadAsStringAsync();
                if (data != null)
                {
                    var dataObj = JObject.Parse(data)["species"].ToString();
                    return dataObj;
                }
                else
                {
                    errorString = "Loading...";
                    return errorString;
                }
            }
            catch (Exception ex)
            {
                errorString = $"Error: {ex}";
                return errorString;
            }
        }
    }
}
