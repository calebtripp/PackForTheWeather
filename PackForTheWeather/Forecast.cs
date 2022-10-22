using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics.Metrics;
using System.IO;
using System.Text.Json.Nodes;

namespace PackForTheWeather
{
    public class Forecast
    {
        public static void ForecastInfo()
        {
            string keyFetch = File.ReadAllText("appsettings.json");
            string APIKey = JObject.Parse(keyFetch).GetValue("APIKey").ToString();
            var client = new HttpClient();

            Console.WriteLine("To cater your outfit to you, please answer the following questions:");
            Console.WriteLine("Please enter the zip code you're traveling to");
            var userZip = Console.ReadLine();

            Console.WriteLine("Consider how YOU feel compared to most people you know with regards to temperature. " +
                "Please respond with 'warmer', 'cooler', or 'same'. For example, I typically feel warmer than those " +
                "around me so I would respond with warmer. We'll use this information to slightly adjust your outfit " +
                "so a warmer person would be wearing shorts before a cooler person.");

            string warmer = Console.ReadLine().ToLower();
            string same = Console.ReadLine().ToLower();
            string cooler = Console.ReadLine().ToLower();

            var geoLocate = $"http://api.openweathermap.org/geo/1.0/zip?zip={userZip},USA&appid={APIKey}";
            var coordinates = client.GetStringAsync(geoLocate).Result;

            JArray parsedApi = JArray.Parse(coordinates);
            var lat = "";
            var lon = "";
            foreach (JObject jObject in parsedApi)
            {
                lat = $"{(string)jObject["lat"]}";
                lon = $"{(string)jObject["lon"]}";
            }

            var forecastReq = $"https://api.openweathermap.org/data/2.5/forecast?lat={lat}&lon={lon}&appid={APIKey}&units =imperial";
            var forecast = client.GetStringAsync(forecastReq).Result;
             
            //apparently openweather only allows calls every 3 hours for forecast, soo... could be an issue if performing multiple same day. 

        }
    }
}
