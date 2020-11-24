
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


namespace moment3
{
    public class CreatePosts
    {
        public string Author { get; set; }
        public string Message { get; set; }
        public void CreateNewPost(out string Name, out string Post)
        {
            do
            {   
                // error check
                Console.ResetColor();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Inga tomma fält ");
                Console.WriteLine("");
                Console.ResetColor();
                
                Console.Write("Skriv ditt namn ");
                // store indata to variable
                Name = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(Name));

            do
            {
                Console.ResetColor();
                Console.Write("Skriv meddelande ");
                // store indata to variable
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
            do
            {
                Console.Write("Skriv in med siffror vilket inlägg du vill radera ");

                string jsonPath = @"posts.json";

                var jsonData = System.IO.File.ReadAllText(jsonPath);

                var postList = JsonConvert.DeserializeObject<List<CreatePosts>>(jsonData)
                ?? new List<CreatePosts>();

                // checking to see if data exists in JSON-file
                if (File.Exists(jsonPath))
                {
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    int indx = 1;
                    foreach (var post in postList)
                    {
                        Console.WriteLine($"[{indx}] {post.Author} - {post.Message}");
                        indx++;
                    }
                };

                // exception handling
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

