
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


namespace pizzaProjekt
{
    public class PayPizza
    {

        public void payMyPizza(){

            Console.Clear();
         
                     
            string jsonPath = @"pizza.json";

            var jsonData = System.IO.File.ReadAllText(jsonPath);

            // deserialize json
            var pizzaList = JsonConvert.DeserializeObject<List<CreatePizza>>(jsonData)
            ?? new List<CreatePizza>();

            // checking to see if data exists in JSON-file
            if (File.Exists(jsonPath))
            {
                int indx = 1;
                int priceCount = 0;
                int total = 0;
                Console.WriteLine("Total");
                Console.WriteLine("________________________");
                foreach (var pizza in pizzaList)
                {
                    total = priceCount += pizza.Price;
                    
                    indx++;
                }
                Console.WriteLine(total + "kr");
            };
            Console.WriteLine(" ");
            Console.WriteLine("1) Betala och avsluta?");
            Console.WriteLine("2) Tillbaka till meny");
   

            switch (Console.ReadLine()){
                 case "1":
                 Console.Clear();
                File.Delete(@"pizza.json");
                if (!File.Exists(jsonPath)){
                FileStream fs = File.Create(jsonPath);
                }
                 Console.Write("Tack för besöket och välkommen åter!");
                 Console.ReadLine();
                    Environment.Exit(0);
                 break;

                case "2":
                 break;
            }
            
        } 

    }

}



