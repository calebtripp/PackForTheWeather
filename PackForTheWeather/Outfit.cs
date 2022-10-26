using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;

namespace PackForTheWeather
{
    public class Outfit
    {
        string top;
        string bottom;
        string footwear;

        string coldAcc;
        string warmAcc;
        string windAcc;
        string midLayer;
        string outerLayer;

        string rainAcc;
        string layer;
        string coldLayer;
        string acc;
        public static void OutfitFactory(string[] args)
        {        
            Outfit coldOutfit = new Outfit();

            coldOutfit.top = "□ Longsleeve";
            coldOutfit.bottom = "□ Pants";
            coldOutfit.midLayer = "□ Hoodie/Sweater";
            coldOutfit.outerLayer = "□ Heavy Coat";
            coldOutfit.footwear = "□ Boots";            
            coldOutfit.acc = "□ Hat & Gloves";                 
            coldOutfit.windAcc = "□ Scarf"; 
            coldOutfit.rainAcc ="□ Umbrella";

            public string coldOutfitList = $"{coldOutfit}";
        }

        //{

        //        var top
        //   var bottom
        //   var shoestyle
        //    var extralayer
        //        var wetweathergear
        //        var rain
        //}



        public static void OutfitFactory()
        {

            var tShirt = 0;
            var shorts = 0;
            var longSleeveT = 0;
            var pants = 0;
            var hoodieSweater = 0;
            var snowBoots = 0;
            var hatGloves = 0;
            var heavyCoat = 0;
            var rainJacketUmbrella = 0;
            var swimsuitTowel = 0;
            var scarf = 0;
            var openToeShoes = 0;
            var closedToeShoes = 0;



            //example setup
            //if (Forecast.feelsLike >= 70 && (same = true || warm = true)
            //{
            //    tShirt++;
            //    shorts++;
            //}

        }

    }
}
