using System;
using Newtonsoft.Json;

namespace WeatherApp.Model
{
    public class WeatherConditions
    {
        [JsonProperty("LocalObservationDateTime")]
        public DateTime LocalObservationDateTime { get; set; }

        [JsonProperty("EpochTime")]
        public int EpochTime { get; set; }

        [JsonProperty("WeatherText")]
        public string WeatherText { get; set; }

        [JsonProperty("WeatherIcon")]
        public int WeatherIcon { get; set; }

        [JsonProperty("HasPrecipitation")]
        public bool HasPrecipitation { get; set; }

        [JsonProperty("PrecipitationType")]
        public object PrecipitationType { get; set; }

        [JsonProperty("IsDayTime")]
        public bool IsDayTime { get; set; }

        [JsonProperty("Temperature")]
        public Temperature Temperature { get; set; }

        [JsonProperty("MobileLink")]
        public string MobileLink { get; set; }

        [JsonProperty("Link")]
        public string Link { get; set; }
    }

    public class Temperature
    {
        [JsonProperty("Metric")]
        public WeatherUnits Metric { get; set; }

        [JsonProperty("Imperial")]
        public WeatherUnits Imperial { get; set; }
    }

    public class WeatherUnits
    {
        [JsonProperty("Value")]
        public string Value { get; set; }

        [JsonProperty("Unit")]
        public string Unit { get; set; }

        [JsonProperty("UnitType")]
        public int UnitType { get; set; }
    }
}