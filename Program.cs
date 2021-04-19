using System;
using System.Collections.Generic;
using System.IO;
using lotr_redactor_console.Classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace lotr_redactor_console
{
    class Program
    {
        static void Main(string[] args)
        {
            string path;

            SavedGame savedGame;

            Dictionary<int, SavedGame> filesNames;

            Console.WriteLine("путь к файлам игры:");
            path = Console.ReadLine();

            string[] files = Directory.GetFiles(path, "SavedGameA", SearchOption.AllDirectories);

            filesNames = new Dictionary<int, SavedGame>(files.Length);

            Console.WriteLine("Список сохранений:");

            for (int i = 0; i < files.Length; i++)
            {
                using (StreamReader reader = File.OpenText(files[i]))
                {
                    JObject o = (JObject)JToken.ReadFrom(new JsonTextReader(reader));

                    string PartyName = (string)o.SelectToken("PartyName");

                    List<Hero> heroes = JsonConvert.DeserializeObject<List<Hero>>(o.SelectToken("HeroInfo").ToString());
                    savedGame = new SavedGame(PartyName, files[i], heroes);

                    filesNames.Add(i, savedGame);

                    Console.WriteLine($"{i}. {PartyName}");
                }
            }

            savedGame = filesNames[int.Parse(Console.ReadLine())];

            Console.WriteLine("Что надо сделать?");
            Console.WriteLine("1. Добавить игрока");
            Console.WriteLine("2. Удалить игрока");

            Console.ReadLine();
        }

        private Dictionary<int, string> availableCharacters()
        {
            Dictionary<int, string> availableCharacters = new Dictionary<int, string>();
           
            availableCharacters.Add(1, "Арагорн");
            availableCharacters.Add(2, "Беравор");
            availableCharacters.Add(3, "Бильбо");
            availableCharacters.Add(4, "Елена");
            availableCharacters.Add(5, "Гимли");
            availableCharacters.Add(6, "Леголас");
            availableCharacters.Add(7, "Арвен");
            availableCharacters.Add(8, "Гэндальф");
            availableCharacters.Add(9, "Элеанор");
            availableCharacters.Add(10, "Дис");
            availableCharacters.Add(11, "Балин");


            return availableCharacters;


        }


    }
}
