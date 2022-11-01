using System.IO;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using PackForTheWeather.Models;

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

//Console.WriteLine("\nHow many days is your trip?");
//int duration = Convert.ToInt32(Console.ReadLine());

//Console.WriteLine("\nConsider how YOU feel in response to temperature compared to most people you know...\n\n" +
//"Please fill in the blank using colder, warmer, or same\n" +
//"I typically feel _______ than most people around me");
//var comfort = Console.ReadLine();

var comfort = "";
    var duration = 0;
var forecastTest = Forecast.GetForecast(zip, duration, comfort);




                Console.WriteLine(forecastTest);

Console.WriteLine(ColdOutfit.crazi);
Console.ReadKey();

