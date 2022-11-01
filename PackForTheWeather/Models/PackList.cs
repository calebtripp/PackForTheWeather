namespace PackForTheWeather.Models
{
    public class PackList
    {
        public static List<string> MakePackList()
        {
            string outfitTest = "test";
            string windAcc = "Scarf";
            string rainAcc = "Umbrella";

            int feelsLike = 50;
            int windSpeed = 10;
            int precipChance = 40;

            List<string> packList = new List<string>();

            //Foreach (var Day in forecastDays)
            //{

                switch (feelsLike)      //Logic is good, need to change out test variable for appropriate outfit
                {
                    case >= 76:
                        packList.Add(outfitTest);     //hot
                        break;
                    case >= 60:
                        packList.Add(outfitTest);     //warm
                        break;
                    case >= 50:
                        packList.Add(outfitTest);     //cool
                        break;
                    case <= 50:
                        packList.Add(outfitTest);     //cold
                        break;
                }

                if (windSpeed >=14 && feelsLike <= 59)
                {
                packList.Add(windAcc);
                }

                if (precipChance >= 40 && feelsLike > 35)
                {
                packList.Add(rainAcc);
                }

                return packList;
        }
        //}
    }
}
