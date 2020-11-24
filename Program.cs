using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace csharptest
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
            Console.Clear();
            Console.WriteLine("Johannes Gästbok");
            Console.WriteLine(" ");
            Console.WriteLine("1) Skriv ett inlägg");
            Console.WriteLine("2) Ta bort inlägg");
            Console.WriteLine(" ");
            Console.WriteLine("3) Avsluta");
            Console.WriteLine(" ");
            // path to json file
            string jsonPath = @"posts.json";

            var jsonData = System.IO.File.ReadAllText(jsonPath);

            // deserialize json
            var postList = JsonConvert.DeserializeObject<List<CreatePosts>>(jsonData)
            ?? new List<CreatePosts>();

            if (File.Exists(jsonPath))
            {

                int indx = 1;
                foreach (var post in postList)
                {
                    Console.WriteLine($"[{indx}] {post.MyName} - {post.MyPost}");
                    indx++;
                }
            };

            switch (Console.ReadLine())
            {
                case "1":
                    // create post
                    var testpost = new CreatePosts();

                    testpost.CreateNewPost(out string Name, out string Post);

                    postList.Add(new CreatePosts()
                    {
                        MyName = Name,
                        MyPost = Post,
                    });

                    jsonData = JsonConvert.SerializeObject(postList);
                    File.WriteAllText(jsonPath, jsonData);

                    if (File.Exists(jsonPath))
                    {

                        int indx = 1;
                        foreach (var post in postList)
                        {
                            Console.WriteLine($"[{indx}] {post.MyName} - {post.MyPost}");
                            indx++;
                        }
                    };
                    return true;

                case "2":
                    // delete post
                Console.Clear();
                var removepost = new DeletePosts();
                removepost.DeletePost();
                    return true;
              
                case "3":
                    // if chosen exit app
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





