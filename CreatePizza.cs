
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


namespace pizzaProjekt
{
    public class CreatePizza
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public void CreateNewPizza(out string Name, out int Price)
        {

            Name = "";
            Price = 0;


            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" /$$      /$$                              ");
            Console.WriteLine("| $$$    /$$$                              ");
            Console.WriteLine("| $$$$  /$$$$  /$$$$$$  /$$$$$$$  /$$   /$$");
            Console.WriteLine("| $$ $$/$$ $$ /$$__  $$| $$__  $$| $$  | $$");
            Console.WriteLine("| $$  $$$| $$| $$$$$$$$| $$  |$$| $$  | $$");
            Console.WriteLine("| $$  $ | $$| $$_____/| $$  | $$| $$  | $$");
            Console.WriteLine("| $$ /  | $$|  $$$$$$$| $$  | $$|  $$$$$$$");
            Console.WriteLine("|__/     |__/ _______/|__/  |__/  ____  $$");
            Console.WriteLine("                                  /$$  | $$");
            Console.WriteLine("                                 |  $$$$$$/");
            Console.WriteLine("                                   ______/ ");

            Console.ResetColor();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("1 ) Pepperoni 85kr");
            Console.WriteLine("");
            Console.Write("2 ) Vesuvio 90kr");
            Console.WriteLine("");
            Console.Write("3 ) Margeritha 70kr");
            Console.WriteLine("");

            switch (Console.ReadLine())
            {
                case "1":

                    Name = "Pepperoni";
                    Price = 85;
                    break;

                case "2":
                    Name = "Vesuvio";
                    Price = 90;
                    break;

                case "3":
                    Name = "Margherita";
                    Price = 70;
                    break;

                default:
                    break;
            }



        }
    }

}

