namespace PackForTheWeather.Models
{
    public class WarmOutfit
    {
        public static void MakeWarmOutfit()
        {
            Outfit warmOutfit = new Outfit();

            warmOutfit.top = "□ Shorts";
            warmOutfit.bottom = "□ Shorts";
            warmOutfit.footwear = "□ Open Toe Shoes";
            warmOutfit.footwear = "□ Shorts";

            warmOutfit.coldAcc = "□ Shorts";
            warmOutfit.warmAcc = "□ Shorts";
            warmOutfit.windAcc = "□ Shorts";
            warmOutfit.midLayer = "□ Shorts";
            warmOutfit.outerLayer = "□ Shorts";

            warmOutfit.rainAcc = "□ Umbrella";
            warmOutfit.extraLayer = "□ Shorts";
            warmOutfit.coldLayer = "□ Shorts";
            warmOutfit.acc = "";
        }
    }
}
