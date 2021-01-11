
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


namespace moment3
{
    public class PayPizza
    {
        public void payMyPizza(){
                        
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

                foreach (var pizza in pizzaList)
                {
                    total = priceCount + pizza.Price;
                    Console.WriteLine($"[{indx}] {pizza.Name} - {pizza.Price} kr");
                    indx++;
                }
            };
        }
    }

}



