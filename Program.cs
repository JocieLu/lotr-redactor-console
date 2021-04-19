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
        static SavedGame savedGame;

        static void Main(string[] args)
        {
            string path;

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

            int action = int.Parse(Console.ReadLine());
            if (action == 1) AddNewHero();
            else RemoveHero();
                
            Console.ReadLine();
        }

        static public void AddNewHero()
        {
            Dictionary<int, string> availableCharacters = AvailableCharacters();
            Dictionary<int, string> availableRoles = AvailableRoles();

            Console.WriteLine("Кого добавляем?");

            foreach (var item in availableCharacters)
            {
                Console.WriteLine($"{item.Key}. {item.Value}");
            }

            Hero newHero = new Hero();
            newHero.Id = int.Parse(Console.ReadLine());

            Console.WriteLine("Какой класс?");
            foreach (var item in availableRoles)
            {
                Console.WriteLine($"{item.Key}. {item.Value}");
            }

            newHero.RoleId = int.Parse(Console.ReadLine());

            savedGame.AddHero(newHero);
        }

        static public void RemoveHero()
        {
            Dictionary<int, string> availableCharacters = AvailableCharacters();

            Console.WriteLine("Кого удаляем?");

            for(int i = 0; i < savedGame.Heroes.Count; i++)
            {
                Console.WriteLine($"{i}. {availableCharacters[savedGame.Heroes[i].Id]}");
            }
            
            int id = int.Parse(Console.ReadLine());

            savedGame.RemoveHero(savedGame.Heroes[id]);
        }

        static public Dictionary<int, string> AvailableCharacters()
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

        static public Dictionary<int, string> AvailableRoles()
        {
            Dictionary<int, string> availableRoles = new Dictionary<int, string>();

            availableRoles.Add(1, "Взломщик");
            availableRoles.Add(2, "Защитник");
            availableRoles.Add(3, "Музыкант");
            availableRoles.Add(4, "Лидер");
            availableRoles.Add(5, "Следопыт");
            availableRoles.Add(6, "Охотник");
            availableRoles.Add(7, "Травник");
            availableRoles.Add(8, "Рудовед");
            availableRoles.Add(9, "Кузнец");
            availableRoles.Add(10, "Путник");
            availableRoles.Add(11, "Смутьян");

            return availableRoles;
        }
    }
}
