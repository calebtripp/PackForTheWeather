using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics.Metrics;
using System.IO;
using System.Text.Json.Nodes;
using System.Text.Json;

namespace PackForTheWeather.Models
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
            var destination = JObject.Parse(coordinates);
            var name = destination.GetValue("name").ToString();
            var lon = destination.GetValue("lon").ToString();
            var lat = destination.GetValue("lat").ToString();

            var forecastRequest = $"https://api.openweathermap.org/data/3.0/onecall?lat={lat}&lon={lon}&exclude=current,minutely,hourly,alerts&appid={APIKey}&units=imperial";
            //$"https://api.openweathermap.org/data/2.5/forecast?lat={lat}&lon={lon}&appid={APIKey}&units=imperial";
            var forecastFromAPI = client.GetStringAsync(forecastRequest).Result;

            // var listOfDays = JObject.Parse(weather).GetValue("list").ToString();

           
        
            var dailyForecast = JObject.Parse(forecastFromAPI).GetValue("daily").ToString();

            var dayOneWeather = JArray.Parse(dailyForecast).ElementAt(0).ToString();

                var temp = JObject.Parse(dayOneWeather).GetValue("feels_like").ToString();
                var feelsLike = JObject.Parse(temp).GetValue("day").ToString();

                var windSpeed = JObject.Parse(dayOneWeather).GetValue("wind_speed").ToString();
                var pop = JObject.Parse(dayOneWeather).GetValue("pop").ToString();

           


            // json["list"][0]["dt"]
            //json["list"][0]["main"]["feels_like"]


            var forecast = $"\nThe forecast for {destination} is \n{forecastFromAPI}  dailyforecast{dailyForecast} feelslike{feelsLike} windspeed{windSpeed} pop {pop} and";
            return forecast; //forecast

            // next step is parse forecast.
            // reference api weater app and possibly something like postman??
            // Read more on the docs for .notation to see if that simplifies things. 



        }
    }
}      