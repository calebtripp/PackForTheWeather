using System.Security.Cryptography.X509Certificates;

namespace PackForTheWeather.Models
{
    public class ColdOutfit
    {
        public string Top { get; set; } = "□ Longsleeve Shirt";
        public string bottom { get; set; } = "□ Pants";
        public string midLayer { get; set; } = "□ Hoodie/Sweater";
        public string outerLayer { get; set; } = "□ Heavy Coat";
        public string footwear { get; set; } = "□ Boots";
        public string acc { get; set; } = "□ Hat & Gloves";
        public string windAcc { get; set; } = "□ Scarf";
        public string rainAcc { get; set; } = "□ Umbrella";


        //public static string MakeColdOutfit()
        //{
        //    Outfit coldOutfit = new Outfit();

        //    coldOutfit.top = "□ Longsleeve Shirt";
        //    coldOutfit.bottom = "□ Pants";
        //    coldOutfit.midLayer = 
        //    coldOutfit.outerLayer = "□ Heavy Coat";
        //    coldOutfit.footwear = "□ Boots";
        //    coldOutfit.acc = "□ Hat & Gloves";
        //    coldOutfit.windAcc = "Scarf";
        //    coldOutfit.rainAcc = "□ Umbrella";

        //    return coldList;
        //}   

    }
}

