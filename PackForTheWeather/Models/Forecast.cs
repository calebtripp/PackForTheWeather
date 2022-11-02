using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics.Metrics;
using System.IO;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections;

namespace PackForTheWeather.Models
{
    public class Forecast
    {
        PackListDictionary suitcase = new PackListDictionary();
        int comfort = 0;
        public PackListDictionary GetForecast(int zip, int duration, int comfort)
        {
            string keyFetch = File.ReadAllText("appsettings.json");
            string APIKey = JObject.Parse(keyFetch).GetValue("APIKey").ToString();

            var client = new HttpClient();

            var apiCoordinateCall = $"http://api.openweathermap.org/geo/1.0/zip?zip={zip},US&appid={APIKey}";
            var coordinates = client.GetStringAsync(apiCoordinateCall).Result;
            var destination = JObject.Parse(coordinates);
            var destName = destination.GetValue("name").ToString();
            var lon = destination.GetValue("lon").ToString();
            var lat = destination.GetValue("lat").ToString();           

            var apiWeatherCall = $"https://api.openweathermap.org/data/3.0/onecall?lat={lat}&lon={lon}&exclude=current,minutely,hourly,alerts&appid={APIKey}&units=imperial";
            var FullForecastFromAPI = client.GetStringAsync(apiWeatherCall).Result;                         
            var dailyForecast = JObject.Parse(FullForecastFromAPI).GetValue("daily").ToString();

            var dayToGet = 0;    

            for (int i = 0; i < duration; i++)
            {
                for (int j = 0; j < duration; j++)
                {
                    dayToGet++;
                }

                var dayParse = JArray.Parse(dailyForecast).ElementAt(dayToGet).ToString();

                var dailyTemps = JObject.Parse(dayParse).GetValue("feels_like").ToString();
                var feelsLike = JObject.Parse(dailyTemps).GetValue("day").ToString();

             double comfAdjust = Convert.ToDouble(feelsLike);
                if (comfort == 1)
                {
                    comfAdjust -= 5; 
                }
                else if (comfort == 2)
                {
                    comfAdjust += 5;
                }               
              
                var windSpeed = JObject.Parse(dayParse).GetValue("wind_speed").ToString();
                var rainChance = JObject.Parse(dayParse).GetValue("pop").ToString();            

                switch (comfAdjust)      //Logic is good, need to change out test variable for appropriate outfit
                {
                    case >= 76:
                        suitcase.packList["T Shirt"]++;
                        suitcase.packList["Shorts"]++;
                        suitcase.packList["Sunscreen, Swimsuit, Towel"]++;
                        suitcase.packList["Open Toe Shoes"]++;
                        switch (Convert.ToDouble(rainChance))
                        {
                            case >= .35:
                                suitcase.packList["Umbrella"]++;
                                break;
                        }
                        break;

                    case >= 60:
                        suitcase.packList["T Shirt"]++;
                        suitcase.packList["Pants"]++;
                        suitcase.packList["Open Toe Shoes"]++;
                        switch (Convert.ToDouble(rainChance))
                        {
                            case >= .35:
                                suitcase.packList["Umbrella"]++;
                                break;
                        }
                        switch (Convert.ToDouble(windSpeed))
                        {
                            case >= 14:
                                suitcase.packList["Hoodie or Sweater"]++;
                                break;
                        }
                        break;
                                               
                    case >= 50:
                        suitcase.packList["Long Sleeve T"]++;
                        suitcase.packList["Pants"]++;
                        suitcase.packList["Hoodie or Sweater"]++;
                        suitcase.packList["Closed Toe Shoes"]++;
                        switch (Convert.ToDouble(rainChance))
                        {
                            case >= .35:
                                suitcase.packList["Umbrella"]++;
                                break;
                        }
                        switch (Convert.ToDouble(windSpeed))
                        {
                            case >= 14:
                                suitcase.packList["Light Jacket"]++;
                                break;
                        }
                        break;                 
                                               
                    case <= 50:
                        suitcase.packList["Long Sleeve T"]++;
                        suitcase.packList["Pants"]++;
                        suitcase.packList["Hoodie or Sweater"]++;
                        suitcase.packList["Heavy Coat"]++;
                        suitcase.packList["Boots"]++;
                        suitcase.packList["Hat and Gloves"]++;
                        switch (Convert.ToDouble(rainChance))
                        {
                            case >= .35:
                                suitcase.packList["Umbrella"]++;
                                break;
                        }
                        switch (Convert.ToDouble(windSpeed))
                        {
                            case >= 14:
                                suitcase.packList["Scarf"]++;
                                break;
                        }
                        break;
                }                
            }
            return suitcase;
        }                
    }
}      