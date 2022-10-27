using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using Microsoft.VisualBasic;

namespace PackForTheWeather
{
    public class Outfit
    {
        public List<Outfit> outfitList = new List<Outfit>();
        string top;
        string bottom;
        string footwear;

        string coldAcc;
        string warmAcc;
        string windAcc;
        string midLayer;
        string outerLayer;

        //  var fields = new List<string>();

        string rainAcc;
        string layer;
        string coldLayer;
        string acc;
        //public Outfit()
        //{ }
        //public Outfit (string top, string bottom)
        //{
        //    Top = top;
        //    Bottom = bottom;

        //    Public string Top { get; set; }
        //    Public string Bottom { get; set; }
        //}


        public static void OutfitFactory()
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

            // Outfit.outfitList.Add(coldOutfit);
        }


        //    //string coldOutfitList = $"{coldOutfit.top}";
        //    //Console.WriteLine(coldOutfitList);


        //    var coldOutfitList = new List<string>();

        //    Type t = coldOutfit.GetType();
        //    PropertyInfo[] pi = t.GetProperties();

        //    foreach (var item in collection)


    }
}

        //{

        //        var top
        //   var bottom
        //   var shoestyle
        //    var extralayer
        //        var wetweathergear
        //        var rain
        //}



        //public static void OutfitFactory()
        //{

        //    var tShirt = 0;
        //    var shorts = 0;
        //    var longSleeveT = 0;
        //    var pants = 0;
        //    var hoodieSweater = 0;
        //    var snowBoots = 0;
        //    var hatGloves = 0;
        //    var heavyCoat = 0;
        //    var rainJacketUmbrella = 0;
        //    var swimsuitTowel = 0;
        //    var scarf = 0;
        //    var openToeShoes = 0;
        //    var closedToeShoes = 0;



        //    //example setup
        //    //if (Forecast.feelsLike >= 70 && (same = true || warm = true)
        //    //{
        //    //    tShirt++;
        //    //    shorts++;
        //    //}

        //}
