
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


namespace moment3
{
    public class CreatePizza
    {
        public string Name{ get; set; }
        public int Price { get; set; }
        public void CreateNewPizza(out string Name, out int Price)
        {


            Name = "";
            Price = 0;
                // user options

                // error check
                Console.ResetColor();
            
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("");
                Console.Clear();
                Console.ResetColor();
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
                // Console.Write("Skriv ditt namn ");
                // store indata to variable
              
            // }
            // while (string.IsNullOrEmpty(Name));

            // do
            // {
            //     Console.ResetColor();
            //     Console.Write("Skriv meddelande ");
            //     // store indata to variable
            //     Post = Console.ReadLine();
            // } while (string.IsNullOrEmpty(Post));

        }
    }
   
}

