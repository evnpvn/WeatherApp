using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;
using Newtonsoft.Json;


namespace WeatherApp.ViewModel.Helpers
{
    public class AccuWeatherHelper
    {
        public const string BaseURL = "http://dataservice.accuweather.com/";
        public const string APIKey = "z5AywUmc1nYepOoQ8Je6AcvNzEl99FMF";

        public const string CityautocompleteEndpoint = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
        public const string CurrentconditionsEndpoint = "currentconditions/v1/{0}?apikey={1}";


        public static async Task<List<City>> GetCitiesAsync(string query)
        {
            List<City> cities = new List<City>();

            string url = BaseURL + string.Format(CityautocompleteEndpoint, APIKey, query);

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);      
                string json = await response.Content.ReadAsStringAsync();
                cities = JsonConvert.DeserializeObject<List<City>>(json);
            }

            return cities;
        }

        public static async Task<WeatherConditions> GetWeatherConditionsAsync(string cityKey)
        {
            WeatherConditions weatherConditions = new WeatherConditions();

            string url = BaseURL + string.Format(CurrentconditionsEndpoint, cityKey, APIKey);

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();
                weatherConditions = JsonConvert.DeserializeObject<List<WeatherConditions>>(json).FirstOrDefault();
            }

            return weatherConditions;
        }
            
    }
}
