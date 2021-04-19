using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace lotr_redactor_console
{
    class Program
    {
        static void Main(string[] args)
        {
            string path;

            Dictionary<int, string> filesNames;
            Dictionary<int, string> fileHeroes;


            Console.WriteLine("путь к файлам игры:");
            path = Console.ReadLine();

            string[] files = Directory.GetFiles(path, "SavedGameA", SearchOption.AllDirectories);

            filesNames = new Dictionary<int, string>(files.Length);

            Console.WriteLine("Список сохранений:");

            for (int i = 0; i < files.Length; i++)
            {
                using (StreamReader reader = File.OpenText(files[i]))
                {
                    JObject o = (JObject)JToken.ReadFrom(new JsonTextReader(reader));

                    string PartyName = (string)o.SelectToken("PartyName");
                    Console.WriteLine($"{i}. {PartyName}");

                    var heroes = o.SelectToken("HeroInfo");
                    foreach(var hero in heroes)
                    {
                        var id = (int)hero.SelectToken("Id");
                    }

                    filesNames.Add(i, files[i]);
                }
            }

            Console.ReadLine();
        }
    }
}
