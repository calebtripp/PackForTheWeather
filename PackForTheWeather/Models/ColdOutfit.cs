namespace PackForTheWeather.Models
{
    public class ColdOutfit
    {      
        public static void MakeColdOutfit()
        {
            Outfit coldOutfit = new Outfit();

            coldOutfit.top = "□ Longsleeve Shirt";
            coldOutfit.bottom = "□ Pants";
            coldOutfit.midLayer = "□ Hoodie/Sweater";
            coldOutfit.outerLayer = "□ Heavy Coat";
            coldOutfit.footwear = "□ Boots";
            coldOutfit.acc = "□ Hat & Gloves";
            coldOutfit.windAcc = "";
            coldOutfit.rainAcc = "□ Umbrella";

            var coldPackList = new List<string>();
            coldPackList.Add(coldOutfit.top);
            coldPackList.Add(coldOutfit.bottom);
            coldPackList.Add(coldOutfit.midLayer);
            coldPackList.Add(coldOutfit.outerLayer);
            coldPackList.Add(coldOutfit.footwear);
            coldPackList.Add(coldOutfit.acc);
            coldPackList.Add(coldOutfit.windAcc);
            coldPackList.Add(coldOutfit.rainAcc);

            var stringlist = coldOutfit.ToString();
            Console.WriteLine(stringlist);
        }
    }
}

