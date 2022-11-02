using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

namespace PackForTheWeather
{
    public class Suitcase
    {
   
                                        ///////////////////////this was a dictionary trial//////////////////////// 

        public string Item { get; set; }
        public int quantity { get; set; }
           
    
            public static void Main()
            {
            var packList = new Dictionary<string, int>();
        
            packList.Add("Shorts", 1);
            packList.Add("Shorts", 3);


            }

                //foreach (var index in Enumerable.Range(111, 3))
                //{
                //    Console.WriteLine($"Student {index} is {students[index].FirstName} {students[index].LastName}");
                //}
                //Console.WriteLine();

                //var students2 = new Dictionary<int, StudentName>()
                //{
                //    [111] = new StudentName { FirstName = "Sachin", LastName = "Karnik", ID = 211 },
                //    [112] = new StudentName { FirstName = "Dina", LastName = "Salimzianova", ID = 317 },
                //    [113] = new StudentName { FirstName = "Andy", LastName = "Ruth", ID = 198 }
                //};

                //foreach (var index in Enumerable.Range(111, 3))
                //{
                //    Console.WriteLine($"Student {index} is {students2[index].FirstName} {students2[index].LastName}");
                //}
            
    }
    
}
