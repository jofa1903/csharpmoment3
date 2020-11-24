
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


namespace csharptest
{
    public class CreatePosts
    {
        public string MyName { get; set; }
        public string MyPost { get; set; }
        public void CreateNewPost(out string Name, out string Post)
        {
            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.Write("Skriv ditt namn ");
                Name = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(Name));

            do
            {
                Console.WriteLine();
                Console.Write("Skriv meddelande ");
                Post = Console.ReadLine();
            } while (string.IsNullOrEmpty(Post));

        }
    }
    public class DeletePosts
    {
        
        public void DeletePost()
        {
            Console.Clear();
            var test = true;
            do{ 
            Console.Write("Skriv in med siffror vilket inlägg du vill radera ");
            
            string jsonPath = @"posts.json";

            var jsonData = System.IO.File.ReadAllText(jsonPath);

            var postList = JsonConvert.DeserializeObject<List<CreatePosts>>(jsonData)
            ?? new List<CreatePosts>();
            
            if (File.Exists(jsonPath))
            {
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                int indx = 1;
                foreach (var post in postList)
                {
                    
                    Console.WriteLine($"[{indx}] {post.MyName} - {post.MyPost}");
                    indx++;
                }
            };
            
            try
            {
                int delIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                postList = JsonConvert.DeserializeObject<List<CreatePosts>>(jsonData)
                ?? new List<CreatePosts>();

                postList.RemoveAt(delIndex);

                jsonData = JsonConvert.SerializeObject(postList);
                File.WriteAllText(jsonPath, jsonData);
                test = false;
            }
            catch (FormatException)
            {   
                Console.ForegroundColor = ConsoleColor.Red; 
                Console.Clear();
                Console.WriteLine("Fel inmatat värde");
                test = true;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.ForegroundColor = ConsoleColor.Red; 
                Console.WriteLine("Fel inmatat värde");
                test = true;
            }
            }while(test);
     

        }
    }

}

