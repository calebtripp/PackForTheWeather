using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PackForTheWeather.Models;
using PackForTheWeather.ViewModel;
using System.Diagnostics;

namespace PackForTheWeather.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        //public IActionResult GetTripInfo(ZipTripComfort input)
        //{
        //    Dictionary<string, int> packList = new Dictionary<string, int>()
        //    {
        //        { "T Shirt", 0 },
        //        { "Long Sleeve T", 0 },
        //        { "Hoodie or Sweater", 0 },
        //        { "Light Jacket", 0 },
        //        { "Heavy Coat", 0 },

        //        { "Pants", 0 },
        //        { "Shorts", 0 },

        //        { "Hat and Gloves", 0 },
        //        { "Scarf", 0 },
        //        { "Umbrella", 0 },
        //        { "Sunscreen, Swimsuit, Towel", 0 },

        //        { "Open Toe Shoes", 0 },
        //        { "Closed Toe Shoes", 0 },
        //        { "Boots", 0 },
        //    };
        //    var client = new HttpClient();
        //    string APIKey = "269fcd68b6d3d0d501d5f58d3d61fc61";
        //    var apiCoordinateCall = $"http://api.openweathermap.org/geo/1.0/zip?zip={input.Zip},US&appid={APIKey}";
        //    var coordinates = client.GetStringAsync(apiCoordinateCall).Result;
        //    var destination = JObject.Parse(coordinates);
        //    var lon = destination.GetValue("lon").ToString();
        //    var lat = destination.GetValue("lat").ToString();

        //    var apiWeatherCall = $"https://api.openweathermap.org/data/3.0/onecall?lat={lat}&lon={lon}&exclude=current,minutely,hourly,alerts&appid={APIKey}&units=imperial";
        //    var FullForecastFromAPI = client.GetStringAsync(apiWeatherCall).Result;
        //    var dailyForecast = JObject.Parse(FullForecastFromAPI).GetValue("daily").ToString();

        //    var dayToGet = input.Trip;

        //    for (int i = 0; i < input.Trip; i++)
        //    {
        //        var dayParse = JArray.Parse(dailyForecast).ElementAt(dayToGet).ToString();

        //        var dailyTemps = JObject.Parse(dayParse).GetValue("feels_like").ToString();
        //        var feelsLike = JObject.Parse(dailyTemps).GetValue("day").ToString();

        //        double comfAdjust = Convert.ToDouble(feelsLike);
        //        if (input.ComfortLevel == 1)
        //        {
        //            comfAdjust -= 5;
        //        }
        //        else if (input.ComfortLevel == 2)
        //        {
        //            comfAdjust += 5;
        //        }

        //        var windSpeed = JObject.Parse(dayParse).GetValue("wind_speed").ToString();
        //        var rainChance = JObject.Parse(dayParse).GetValue("pop").ToString();

        //        switch (comfAdjust)
        //        {
        //            case >= 76:
        //                packList["T Shirt"]++;
        //                packList["Shorts"]++;
        //                packList["Sunscreen, Swimsuit, Towel"]++;
        //                packList["Open Toe Shoes"]++;
        //                switch (Convert.ToDouble(rainChance))
        //                {
        //                    case >= .35:
        //                        packList["Umbrella"]++;
        //                        break;
        //                }
        //                break;

        //            case >= 60:
        //                packList["T Shirt"]++;
        //                packList["Pants"]++;
        //                packList["Open Toe Shoes"]++;
        //                switch (Convert.ToDouble(rainChance))
        //                {
        //                    case >= .35:
        //                        packList["Umbrella"]++;
        //                        break;
        //                }
        //                switch (Convert.ToDouble(windSpeed))
        //                {
        //                    case >= 14:
        //                        packList["Hoodie or Sweater"]++;
        //                        break;
        //                }
        //                break;

        //            case >= 50:
        //                packList["Long Sleeve T"]++;
        //                packList["Pants"]++;
        //                packList["Hoodie or Sweater"]++;
        //                packList["Closed Toe Shoes"]++;
        //                switch (Convert.ToDouble(rainChance))
        //                {
        //                    case >= .35:
        //                        packList["Umbrella"]++;
        //                        break;
        //                }
        //                switch (Convert.ToDouble(windSpeed))
        //                {
        //                    case >= 14:
        //                        packList["Light Jacket"]++;
        //                        break;
        //                }
        //                break;

        //            case <= 50:
        //                packList["Long Sleeve T"]++;
        //                packList["Pants"]++;
        //                packList["Hoodie or Sweater"]++;
        //                packList["Heavy Coat"]++;
        //                packList["Boots"]++;
        //                packList["Hat and Gloves"]++;
        //                switch (Convert.ToDouble(rainChance))
        //                {
        //                    case >= .35:
        //                        packList["Umbrella"]++;
        //                        break;
        //                }
        //                switch (Convert.ToDouble(windSpeed))
        //                {
        //                    case >= 14:
        //                        packList["Scarf"]++;
        //                        break;
        //                }
        //                break;
        //        }
        //    }


        //    var vm = new GetTripInfoViewModel();

        //    vm.PackList = packList;
        //    return View(vm);
        //}
    




////////////////////////////////////////////////////////////////////////////////////////////////////////

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}