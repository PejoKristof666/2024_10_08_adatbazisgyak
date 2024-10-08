using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_10_08_adatbazisgyak
{
    public class PokemonData
    {
        public static List<PokemonData> pokemonList = new List<PokemonData>();
        public int id { get; set; }
        public string name { get; set; }
        public int point { get; set; }
    }
}
