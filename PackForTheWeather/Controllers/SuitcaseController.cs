using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using PackForTheWeather.Models;
using PackForTheWeather.ViewModel;
using System.IO;
using System.Configuration;
using Microsoft.Configuration.ConfigurationBuilders;

namespace PackForTheWeather.Controllers
{
    public class SuitcaseController : Controller
    {     

        public IActionResult Index()
        {
            var ztp = new ZipTripComfort();
            return View(ztp);
        }

        public IActionResult GetTripInfo(ZipTripComfort input)
            /////////////////////////////////
            ////////////////////////////
            /////////////////////////
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

            //////////////////////////////////////////////
            //////////////////////////////////////////
            //////////////////////////////

            //GetValue///////////////////////////////////////////////////////////////////
            //   public class TestNumModel : PageModel
            //{
            //    private readonly IConfiguration Configuration;

            //    public TestNumModel(IConfiguration configuration)
            //    {
            //        Configuration = configuration;
            //    }

            //    public ContentResult OnGet()
            //    {
            //        var number = Configuration.GetValue<int>("NumberKey", 99);
            //        return Content($"{number}");
            //    }
            //}

            //Key per file configuration provider////////////////////////////////////////////////////////

            //var builder = WebApplication.CreateBuilder();
            //var build = new ConfigurationBuilder();
            //build.ConfigureAppConfiguration((hostingContext, config) =>
            // {
            //     var path = Path.Combine(
            //         Directory.GetCurrentDirectory(), "path/to/files");
            //     config.AddKeyPerFile(directoryPath: path, optional: true);
            // });
            // build.AddKeyPerFile(directoryPath: C:\Users\caleb\OneDrive\Desktop\Repos\PackForTheWeather\PackForTheWeather\appsettings.json, optional: true);

            //microsoft configuration json nuget package

            //SimpleJSONConfig Builder/////////////////////////////////////////////

            //  Xml only??

            //custom key value config builder

            //string GetValue(string key)
            //{
            //    AppSettingsSectionHandler

            //    return;
            //}


           // var builder = new ConfigurationBuilder();
           // var dirpath = "C:\\Users\\caleb\\OneDrive\\Desktop\\Repos\\PackForTheWeather\\PackForTheWeather\\appsettings.json";
           // var testy = builder.AddKeyPerFile(dirpath);
           //// var jsonBuilt = builder.AddJsonFile("appsettings.json").ToString();
           // var APIKey = JObject.Parse("appsettings.json").GetValue("APIKey");







            //Configuration manager
            //var cm = new ConfigurationManager();
            //cm.Get("appsettings.json");


            //ConfigurationManager.AppSettings


            //JSON Configuration provider///////////////////////////////////////////////////////////

            //var builder = WebApplication.CreateBuilder();

            //    builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
            //    {
            //        config.AddJsonFile("appsettings.json",
            //                           optional: true,
            //                           reloadOnChange: true);
            //    });

            //    builder.Services.AddRazorPages();

            //    var app = builder.Build();

            //var APIKey = builder.Configuration.GetConnectionString("APIKey");
            //var apiR = APIKey;
            ////////////////////////////
            ////////////////////////////////////////
            //////////////////////////////

            var client = new HttpClient();
            string APIKey = "269fcd68b6d3d0d501d5f58d3d61fc61";
            var apiCoordinateCall = $"http://api.openweathermap.org/geo/1.0/zip?zip={input.Zip},US&appid={APIKey}";
            var coordinates = client.GetStringAsync(apiCoordinateCall).Result;
            var destination = JObject.Parse(coordinates);
            var lon = destination.GetValue("lon").ToString();
            var lat = destination.GetValue("lat").ToString();

            var apiWeatherCall = $"https://api.openweathermap.org/data/3.0/onecall?lat={lat}&lon={lon}&exclude=current,minutely,hourly,alerts&appid={APIKey}&units=imperial";
            var FullForecastFromAPI = client.GetStringAsync(apiWeatherCall).Result;
            var dailyForecast = JObject.Parse(FullForecastFromAPI).GetValue("daily").ToString();

            var dayToGet = input.Trip;

            for (int i = 0; i < input.Trip; i++)
            {
                var dayParse = JArray.Parse(dailyForecast).ElementAt(dayToGet).ToString();

                var dailyTemps = JObject.Parse(dayParse).GetValue("feels_like").ToString();
                var feelsLike = JObject.Parse(dailyTemps).GetValue("day").ToString();

                double comfAdjust = Convert.ToDouble(feelsLike);
                if (input.ComfortLevel == 1)
                {
                    comfAdjust -= 5;
                }
                else if (input.ComfortLevel == 2)
                {
                    comfAdjust += 5;
                }

                var windSpeed = JObject.Parse(dayParse).GetValue("wind_speed").ToString();
                var rainChance = JObject.Parse(dayParse).GetValue("pop").ToString();

                switch (comfAdjust)
                {
                    case >= 76:
                        packList["T Shirt"]++;
                        packList["Shorts"]++;
                        packList["Sunscreen, Swimsuit, Towel"]++;
                        packList["Open Toe Shoes"]++;
                        switch (Convert.ToDouble(rainChance))
                        {
                            case >= .35:
                                packList["Umbrella"]++;
                                break;
                        }
                        break;

                    case >= 60:
                        packList["T Shirt"]++;
                        packList["Pants"]++;
                        packList["Open Toe Shoes"]++;
                        switch (Convert.ToDouble(rainChance))
                        {
                            case >= .35:
                                packList["Umbrella"]++;
                                break;
                        }
                        switch (Convert.ToDouble(windSpeed))
                        {
                            case >= 14:
                                packList["Hoodie or Sweater"]++;
                                break;
                        }
                        break;

                    case >= 50:
                        packList["Long Sleeve T"]++;
                        packList["Pants"]++;
                        packList["Hoodie or Sweater"]++;
                        packList["Closed Toe Shoes"]++;
                        switch (Convert.ToDouble(rainChance))
                        {
                            case >= .35:
                                packList["Umbrella"]++;
                                break;
                        }
                        switch (Convert.ToDouble(windSpeed))
                        {
                            case >= 14:
                                packList["Light Jacket"]++;
                                break;
                        }
                        break;

                    case <= 50:
                        packList["Long Sleeve T"]++;
                        packList["Pants"]++;
                        packList["Hoodie or Sweater"]++;
                        packList["Heavy Coat"]++;
                        packList["Boots"]++;
                        packList["Hat and Gloves"]++;
                        switch (Convert.ToDouble(rainChance))
                        {
                            case >= .35:
                                packList["Umbrella"]++;
                                break;
                        }
                        switch (Convert.ToDouble(windSpeed))
                        {
                            case >= 14:
                                packList["Scarf"]++;
                                break;
                        }
                        break;
                }
            }
           


            // ===========================================================================



            var vm = new GetTripInfoViewModel();

            vm.PackList = packList;
            return View(vm);

            ///////////////////////////
            ////////////////////////////
            /////////////////////////////
        }
    }
}
