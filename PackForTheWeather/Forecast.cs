using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics.Metrics;
using System.IO;
using System.Text.Json.Nodes;

namespace PackForTheWeather
{
    public class Forecast
    {

        public static void ForecastInfo(int zip, int duration, string comfort)
        {


            string keyFetch = File.ReadAllText("appsettings.json");
            string APIKey = JObject.Parse(keyFetch).GetValue("APIKey").ToString();
            var client = new HttpClient();



            string warmer = Console.ReadLine().ToLower();
            string same = Console.ReadLine().ToLower();
            string colder = Console.ReadLine().ToLower();

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
            Console.WriteLine(forecast);
            //apparently openweather only allows calls every 3 hours for forecast, soo... could be an issue if performing multiple same day. 
        }
    }
}
