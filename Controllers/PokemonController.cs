using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokeApi.Models;
using Newtonsoft.Json;
using System.Text;
using System.IO;

namespace PokeApi.Controllers
{
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IHttpClientFactory clientFactory;
        private List<Pokemon> pokemonList;
        private string url = "http://pokeapi.co/api/v2/pokemon?limit=2000";


        public PokemonController(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
            pokemonList = new List<Pokemon>();
        }

        [HttpGet]
        [Route("/api/pokemon")]
        public async Task<IActionResult> GetPokemon()
        {
            try
            {
                var client = clientFactory.CreateClient();
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<RootObject>(json);
                return Ok(data.Results);
            }
            catch (Exception ex)
            {
                return NotFound($"Pokemons not found. Contact the Pokemon Master. {ex}");
            }
        }

        [HttpGet]
        [Route("/api/pokemon/{name}")]
        public async Task<IActionResult> GetPokemonByName(string name)
        {
            try
            {
                var client = clientFactory.CreateClient();
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<RootObject>(json);

                foreach (var pokemon in data.Results)
                {
                    if (pokemon.Name == name)
                    {
                        pokemonList.Clear();
                        pokemonList.Add(pokemon);
                        return Ok(pokemonList);
                    }
                    else if (pokemon.Name.Contains(name))
                    {
                        pokemonList.Add(pokemon);
                    }
                }
                return Ok(pokemonList);
            }
            catch (Exception ex)
            {
                return NotFound($"Pokemon not found. Maybe it's not a pokemon name. {ex}");
            }
        }

        [HttpGet]
        [Route("/api/pokemon/{name}/download")]
        public async Task<FileStreamResult> DownloadPokemon(string name)
        {
            var url = $"http://pokeapi.co/api/v2/pokemon/{name}";
            var client = clientFactory.CreateClient();
            var response = await client.GetStringAsync(url);
            // return Content(response, "text/plain");
            // return File(Encoding.UTF8.GetBytes(response), "text/plain", "MyPokemon.txt");
            
            Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(response));
            string mimeType = "text/plain";
            return new FileStreamResult(stream, mimeType)
            {
                FileDownloadName = "MyPokemon.txt"
            };
        }
    }
}
