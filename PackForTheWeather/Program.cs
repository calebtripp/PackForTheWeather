using System.IO;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;
using PackForTheWeather;
using System.Collections.Generic;


//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllersWithViews();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();
Console.WriteLine("To cater your outfit to you, please answer the following questions:");
Console.WriteLine("Please enter the zip code you're traveling to");
int zip = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("How long is your trip?");
int duration = Convert.ToInt32(Console.ReadLine);

Console.WriteLine("Consider how YOU feel about temperature compared to most people you know..." +
    "Do you typically feel warmer than most? colder than most? about the same?." +
    "Please respond with 'warmer', 'colder', or 'same'. For example, I typically feel warmer than those " +
    "around me so my response would be warmer. We'll use this information to slightly adjust your outfit " +
    "so someone feeling warmer than most would wear shorts on a day that someone who was colder might not be ready for yet." +
"please fill in the blank using colder, warmer, or same in the following sentence. I typically feel _______than most people around me");
var comfort = Console.ReadLine();

Outfit outfitTrial = new Outfit();
Console.WriteLine(outfitTrial.outfitList);
//var ForecastDisplay = 
Forecast.ForecastInfo(zip, duration, comfort);
Console.WriteLine();



//Console.WriteLine($"? {outfitTrial.}");
//f Console.WriteLine($" Year: {Car.Year}\n 
    //Make: {Car.Make}\n Model: {Car.Model}\n Engine Noise: {Car.EngineNoise}\n Honk Noise: {Car.HonkNoise}\n Driveable?: {Car.IsDriveable}\n");