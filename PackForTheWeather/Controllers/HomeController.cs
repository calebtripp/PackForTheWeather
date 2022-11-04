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
            var ztp = new ZipTripComfort();
            return View(ztp);
        }

        public IActionResult GetTripInfo(ZipTripComfort input)
        {
            Dictionary<string, int> packList = new Dictionary<string, int>()
            {
                { "T Shirt", 0 },
                { "Long Sleeve T", 0 },
                { "Hoodie or Sweater", 0 },
                { "Light Jacket", 0 },
                { "Heavy Coat", 0 },

                { "Pants", 0 },
                { "Shorts", 0 },

                { "Hat and Gloves", 0 },
                { "Scarf", 0 },
                { "Umbrella", 0 },
                { "Sunscreen, Swimsuit, Towel", 0 },

                { "Open Toe Shoes", 0 },
                { "Closed Toe Shoes", 0 },
                { "Boots", 0 },
            };

            var key = System.IO.File.ReadAllText("appsettings.json");
            string APIKey = JObject.Parse(key).GetValue("APIKey").ToString();

            var client = new HttpClient();

            var apiCoordinateCall = $"http://api.openweathermap.org/geo/1.0/zip?zip={input.Zip},US&appid={APIKey}";
            var coordinates = client.GetStringAsync(apiCoordinateCall).Result;

            var destination = JObject.Parse(coordinates);
            var lon = destination.GetValue("lon").ToString();
            var lat = destination.GetValue("lat").ToString();

            var apiWeatherCall = $"https://api.openweathermap.org/data/3.0/onecall?lat={lat}&lon={lon}&exclude=current,minutely,hourly,alerts&appid={APIKey}&units=imperial";
            var FullForecastFromAPI = client.GetStringAsync(apiWeatherCall).Result;
            var dailyForecast = JObject.Parse(FullForecastFromAPI).GetValue("daily").ToString();

            var dayToGet = input.Trip -= 1; //enables correct day and correct day total to be selected from forecast via element indexing.

            int bootC = 0;
            int scarfC = 0;
            int umbrellaC = 0;
            int heavyCoatC = 0;
            int hatGloves = 0;
            int cTShoes = 0;
            int lightJacketC = 0;
            int hoodieSweaterC = 0;
            int oTShoes = 0;
            int swimC = 0;

            for (int i = 0; i <= input.Trip; i++)
            {
                var dayParse = JArray.Parse(dailyForecast).ElementAt(dayToGet).ToString();
                var dailyTemps = JObject.Parse(dayParse).GetValue("feels_like").ToString();
                var feelsLike = JObject.Parse(dailyTemps).GetValue("day").ToString();

                var windSpeed = JObject.Parse(dayParse).GetValue("wind_speed").ToString();
                var rainChance = JObject.Parse(dayParse).GetValue("pop").ToString();

                double comfAdjust = Convert.ToDouble(feelsLike);
                if (input.ComfortLevel == "I feel colder than most")
                {
                    comfAdjust -= 5;
                }
                else if (input.ComfortLevel == "I feel warmer than most")
                {
                    comfAdjust += 5;
                }
                switch (comfAdjust)
                {
                    case >= 76:
                        packList["T Shirt"]++;
                        packList["Shorts"]++;
                        if (swimC == 0)
                        {
                            packList["Sunscreen, Swimsuit, Towel"]++;
                            swimC++;
                        }
                        if (oTShoes == 0)
                        {
                            packList["Open Toe Shoes"]++;
                            oTShoes++;
                        }
                        if (Convert.ToDouble(rainChance) >= .35 && umbrellaC == 0)
                        {
                            packList["Umbrella"]++;
                            umbrellaC++;
                        }
                        break;

                    case >= 60:
                        packList["T Shirt"]++;
                        packList["Pants"]++;
                        if (oTShoes == 0)
                        {
                            packList["Open Toe Shoes"]++;
                            oTShoes++;
                        }
                        if (Convert.ToDouble(rainChance) >= .35 && umbrellaC == 0)
                        {
                            packList["Umbrella"]++;
                            umbrellaC++;
                        }
                        if ((Convert.ToDouble(windSpeed) >= 14 && hoodieSweaterC == 0))
                        {
                            packList["Hoodie or Sweater"]++;
                            hoodieSweaterC++;
                        }
                        break;

                    case >= 50:
                        packList["Long Sleeve T"]++;
                        packList["Pants"]++;
                        if (cTShoes == 0)
                        {
                            packList["Closed Toe Shoes"]++;
                            cTShoes++;
                        }
                        if (Convert.ToDouble(rainChance) >= .35 && umbrellaC == 0)
                        {
                            packList["Umbrella"]++;
                            umbrellaC++;
                        }
                        if (hoodieSweaterC == 0)
                        {
                            packList["Hoodie or Sweater"]++;
                            hoodieSweaterC++;
                        }
                        if (Convert.ToDouble(windSpeed) >= 14 && lightJacketC == 0)
                        {
                            packList["Light Jacket"]++;
                            lightJacketC++;
                        }
                        break;

                    case < 50:
                        packList["Long Sleeve T"]++;
                        packList["Pants"]++;
                        if (hoodieSweaterC == 0)
                        {
                            packList["Hoodie or Sweater"]++;
                            hoodieSweaterC++;
                        }
                        if (heavyCoatC == 0)
                        {
                            packList["Heavy Coat"]++;
                            heavyCoatC++;
                        }
                        if (bootC == 0)
                        {
                            packList["Boots"]++;
                            bootC++;
                        }
                        if (hatGloves == 0)
                        {
                            packList["Hat and Gloves"]++;
                            hatGloves++;
                        }
                        if (Convert.ToDouble(windSpeed) >= 14 && scarfC == 0)
                        {
                            packList["Scarf"]++;
                            scarfC++;
                        }
                        if (Convert.ToDouble(rainChance) >= .35 && umbrellaC == 0)
                        {
                            packList["Umbrella"]++;
                            umbrellaC++;
                        }
                        break;
                }
            }

            var vm = new GetTripInfoViewModel();
            vm.PackList = packList;
            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}