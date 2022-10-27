using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics.Metrics;
using System.IO;
using System.Text.Json.Nodes;

namespace PackForTheWeather
{
    public class Forecast
    {

        public static string GetForecast(int zip, int duration, string comfort)
        {
            string keyFetch = File.ReadAllText("appsettings.json");
            string APIKey = JObject.Parse(keyFetch).GetValue("APIKey").ToString();
   
            var client = new HttpClient();
      

            //for duration, API returns 5 days. If less than 5 days, duration - 5 = difference. Ignore last 2 days. 
            //for comfort, use colder temp settings, may be as simple as add mid layer, or as complex as a sliding scale. 


            var coordinatesFromZip = $"http://api.openweathermap.org/geo/1.0/zip?zip={zip},US&appid={APIKey}";
            var coordinates = client.GetStringAsync(coordinatesFromZip).Result;          
            var destination = JObject.Parse(coordinates).GetValue("name").ToString();
            var lon = JObject.Parse(coordinates).GetValue("lon").ToString();
            var lat = JObject.Parse(coordinates).GetValue("lat").ToString();         

            var forecastReq = $"https://api.openweathermap.org/data/2.5/forecast?lat={lat}&lon={lon}&appid={APIKey}&units =imperial";
            var weather = client.GetStringAsync(forecastReq).Result;
            var forecast = $"\nThe forecast for {destination} is \n{weather}";
            return forecast;           
        }
    }
}
