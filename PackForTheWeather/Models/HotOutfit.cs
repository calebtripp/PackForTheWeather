﻿namespace PackForTheWeather.Models
{
    public class HotOutfit
    {
        public static void MakeHotOutfit()
        {
            Outfit hotOutfit = new Outfit();

            hotOutfit.top = "□ T Shirt";
            hotOutfit.bottom = "□ Shorts";           
           
            hotOutfit.footwear = "□ Open Toe Shoes";
            hotOutfit.acc = "□ Sunscreen, Swimsuit, Towel";        
            hotOutfit.rainAcc = "□ Umbrella";            
        }
    }
}