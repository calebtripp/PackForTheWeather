namespace PackForTheWeather.Models
{
    public class PackList
    {
        public static List<string> MakePackList()
        {
            string test = "test";
            int feelsLike = 50;
            List<string> packList = new List<string>();

            //Foreach (var Day in forecastDays)
            //{

                switch (feelsLike)      //Logic is good, need to change out test variable for appropriate outfit
                {
                    case >= 76:
                        packList.Add(test);     //hot
                        break;
                    case >= 60:
                        packList.Add(test);     //warm
                        break;
                    case >= 50:
                        packList.Add(test);     //cool
                        break;
                    case <= 50:
                        packList.Add(test);     //cold
                        break;
                }
                return packList;
        }
        //}
    }
}
