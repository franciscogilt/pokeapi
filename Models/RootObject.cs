using System.Collections.Generic;

namespace PokeApi.Models
{
    public class RootObject
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<Pokemon> Results { get; set; }
    }
}