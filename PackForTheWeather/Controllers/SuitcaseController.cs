using Microsoft.AspNetCore.Mvc;
using PackForTheWeather.Models;

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
        {
            var f = new Forecast();

            var dict = f.GetForecast(input.Zip, input.Trip, input.ComfortLevel);
            return View(dict);  
        }

    }
}
