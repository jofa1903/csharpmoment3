
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


namespace pizzaProjekt
{
    public class DeletePizza
    {

        public void DeleteMyPizza()
        {
            Console.Clear();
            var test = true;
            do
            {
                Console.Write("Skriv in med siffror vilket inlägg du vill radera ");

                string jsonPath = @"pizza.json";

                var jsonData = System.IO.File.ReadAllText(jsonPath);

                var pizzaList = JsonConvert.DeserializeObject<List<CreatePizza>>(jsonData)
                ?? new List<CreatePizza>();

                // checking to see if data exists in JSON-file
                if (File.Exists(jsonPath))
                {
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    int indx = 1;
                    foreach (var pizza in pizzaList)
                    {
                        Console.WriteLine($"[{indx}] {pizza.Name}");
                        indx++;
                    }
                };

                // exception handling
                try
                {
                    int delIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                    pizzaList = JsonConvert.DeserializeObject<List<CreatePizza>>(jsonData)
                    ?? new List<CreatePizza>();

                    pizzaList.RemoveAt(delIndex);

                    jsonData = JsonConvert.SerializeObject(pizzaList);
                    File.WriteAllText(jsonPath, jsonData);
                    test = false;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Clear();
                    Console.WriteLine("Fel inmatat värde");
                    Console.WriteLine("");
                    Console.ResetColor();
                    test = true;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fel inmatat värde");
                    Console.WriteLine("");
                    Console.ResetColor();
                    test = true;
                }
            } while (test);
        }
    }

}

