using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics.Metrics;
using System.IO;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Diagnostics;
using System.Collections.Generic;

namespace PackForTheWeather.Models
{
    public class Forecast
    {

        public static int tShirtQ = 0;
        public static int shortQ = 0;


        Dictionary<string,int> PackList = new Dictionary<string, int>()
                {
                    {"Shorts",shortQ},
                     {"TShirt",tShirtQ }

                };
        public static string GetForecast(int zip, int duration, string comfort)
        {
            string keyFetch = File.ReadAllText("appsettings.json");
            string APIKey = JObject.Parse(keyFetch).GetValue("APIKey").ToString();

            var client = new HttpClient();


            var apiCoordinateCall = $"http://api.openweathermap.org/geo/1.0/zip?zip={zip},US&appid={APIKey}";
            var coordinates = client.GetStringAsync(apiCoordinateCall).Result;
            var destination = JObject.Parse(coordinates);
            var name = destination.GetValue("name").ToString();
            var lon = destination.GetValue("lon").ToString();
            var lat = destination.GetValue("lat").ToString();
           

            var apiWeatherCall = $"https://api.openweathermap.org/data/3.0/onecall?lat={lat}&lon={lon}&exclude=current,minutely,hourly,alerts&appid={APIKey}&units=imperial";
            var FullForecastFromAPI = client.GetStringAsync(apiWeatherCall).Result;                         
            var dailyForecast = JObject.Parse(FullForecastFromAPI).GetValue("daily").ToString();

            var dayToGet = 0;           
            var dayList = new List<Day>();
            var dOne = new Day();           

            for (int i = 0; i < duration; i++)
            {
                for (int j = 0; j < duration; j++)
                {
                    dayToGet++;
                }

                var dayParse = JArray.Parse(dailyForecast).ElementAt(dayToGet).ToString();

                var temp = JObject.Parse(dayParse).GetValue("feels_like").ToString();
                var feelsLike = JObject.Parse(temp).GetValue("day").ToString();

                var windSpeed = JObject.Parse(dayParse).GetValue("wind_speed").ToString();
                var rainChance = JObject.Parse(dayParse).GetValue("pop").ToString();

                dOne.FeelsLike = Convert.ToDouble(feelsLike);
                dOne.WindSpeed = Convert.ToDouble(windSpeed);
                dOne.RainChance = Convert.ToDouble(rainChance);
                dayList.Add(dOne);


                shortQ++;

                //int tShirtQ = 0;
                //int shortQ = 0;          

                //var PackList = new Dictionary<string, int>()
                //{
                //    {"Shorts",shortQ},
                //     {"TShirt",tShirtQ }                 
                //};

            }                                  
                       
            return dayList.ToString();

        }


    }
}      