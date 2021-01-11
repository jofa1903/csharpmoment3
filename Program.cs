using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace moment3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }
        private static bool MainMenu()
        {
            // print options to console
            Console.ResetColor();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Luigis Pizza");
            Console.ResetColor();
            Console.WriteLine(" ");
            Console.WriteLine("1) Pizzameny");
            Console.WriteLine("2) Ta bort vara ur varukorgen");
            Console.WriteLine("3) Betala");
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("4) Avsluta");
            Console.ResetColor();
            Console.WriteLine(" ");
            Console.WriteLine("Varukorgen");
            Console.ForegroundColor = ConsoleColor.Yellow;
       
            // path to json file
            string jsonPath = @"pizza.json";

            var jsonData = System.IO.File.ReadAllText(jsonPath);

            // deserialize json
            var pizzaList = JsonConvert.DeserializeObject<List<CreatePizza>>(jsonData)
            ?? new List<CreatePizza>();

            // checking to see if data exists in JSON-file
            if (File.Exists(jsonPath))
            {

                int indx = 1;
                foreach (var pizza in pizzaList)
                {
                    Console.WriteLine($"[{indx}] {pizza.Name} - {pizza.Price} kr");
                    indx++;
                }
            };
            Console.ResetColor();

            // user options
            switch (Console.ReadLine())
            {
                case "1":
                    // create post
                    var testpizza = new CreatePizza();

                    testpizza.CreateNewPizza(out string Name, out int Price);
                    pizzaList.Add(new CreatePizza()
                    {
                        Name = Name,
                        Price = Price
                 
                    });
                    
                    jsonData = JsonConvert.SerializeObject(pizzaList);
                    File.WriteAllText(jsonPath, jsonData);
                    // checking to see if data exists in JSON-file and printing new data to console
                    if (File.Exists(jsonPath))
                    {

                        int indx = 1;
                        foreach (var pizza in pizzaList)
                        {
                            Console.WriteLine($"[{indx}] {pizza.Name} - {pizza.Price}kr");
                            indx++;
                        }
                    };
                    return true;

                case "2":
                    // delete post
                    var removepizza = new DeletePizza();
                    removepizza.DeleteMyPizza();
                    return true;

                case "3":
                    var paypizza = new PayPizza();
                    paypizza.payMyPizza();
                    return true;

                case "4":
                // if chosen exit app
                File.Delete(@"pizza.json");
                if (!File.Exists(jsonPath)){
                FileStream fs = File.Create(jsonPath);
                }
                Console.Clear();
                Console.WriteLine("Adios!");
                Console.WriteLine("");
                return false;

                default:
                    return true;
            }

        }

    }
}





