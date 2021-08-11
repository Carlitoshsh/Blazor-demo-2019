using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTest.Server.Entities.PokemonAPI
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 

    public class MainRegion
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Language
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Name
    {
        public Language language { get; set; }
        public string name { get; set; }
    }

    public class PokemonSpecy
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class GenerationProperties
    {
        public List<Ability2> abilities { get; set; }
        public int id { get; set; }
        public MainRegion main_region { get; set; }
        public List<Move2> moves { get; set; }
        public string name { get; set; }
        public List<Name> names { get; set; }
        public List<PokemonSpecy> pokemon_species { get; set; }
        public List<object> types { get; set; }
        public List<VersionGroup> version_groups { get; set; }
    }
}
