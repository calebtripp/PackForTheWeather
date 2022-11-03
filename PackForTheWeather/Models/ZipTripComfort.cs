using System.Reflection.Metadata.Ecma335;

namespace PackForTheWeather.Models
{
    public class ZipTripComfort
    {
        public int Zip { get; set; }
        public int Trip { get; set; }
        public int ComfortLevel { get; set; }
        public string APIKey { get; set; }

    }
}
