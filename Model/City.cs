using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherApp.Model
{
    public class City
    {
        [JsonProperty("Version")]
        public int Version { get; set; }

        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Rank")]
        public int Rank { get; set; }

        [JsonProperty("LocalizedName")]
        public string LocalizedName { get; set; }

        [JsonProperty("Country")]
        public Area Country { get; set; }

        [JsonProperty("AdministrativeArea")]
        public Area AdministrativeArea { get; set; }
    }

    public class Area
    {
        [JsonProperty("ID")]
        public string ID { get; set; }

        [JsonProperty("LocalizedName")]
        public string LocalizedName { get; set; }
    }
}
