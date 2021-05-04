using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using lotr_redactor_console.Classes;
using Newtonsoft.Json;

namespace lotr_redactor_console
{
    class Program
    {
        static SavedGame savedGame;

        static void Main(string[] args)
        {
            Dictionary<int, SavedGame> filesNames;

            Console.WriteLine("путь к файлам игры:");
            string path = Console.ReadLine();

            string[] files = Directory.GetFiles(path, "SavedGameA", SearchOption.AllDirectories);

            filesNames = new Dictionary<int, SavedGame>(files.Length);

            Console.WriteLine("Список сохранений:");

            for (int i = 0; i < files.Length; i++)
            {
                using StreamReader reader = File.OpenText(files[i]);
                string json = reader.ReadToEnd();

                savedGame = JsonConvert.DeserializeObject<SavedGame>(json);
                savedGame.Description = json;
                savedGame.Path = files[i];

                filesNames.Add(i, savedGame);

                Console.WriteLine($"{i}. {savedGame.PartyName}");
            }

            savedGame = filesNames[int.Parse(Console.ReadLine())];

            Console.WriteLine("Что надо сделать?");
            Console.WriteLine("1. Добавить игрока");
            Console.WriteLine("2. Удалить игрока");

            int action = int.Parse(Console.ReadLine());
            if (action == 1) AddNewHero();
            else RemoveHero();

            string jsonNewHeroes = $"{JsonConvert.SerializeObject(savedGame.HeroInfo, Formatting.Indented)},";

            int firstPoint = savedGame.Description.LastIndexOf("HeroInfo") + 10;
            int lastPoint = savedGame.Description.LastIndexOf("ItemIds") -1;

            savedGame.Description = savedGame.Description.Remove(firstPoint, lastPoint - firstPoint);
            savedGame.Description = savedGame.Description.Insert(firstPoint, jsonNewHeroes);
            
            using (StreamWriter sw = new StreamWriter(savedGame.Path, false, System.Text.Encoding.Default))
            {
               sw.WriteLine(savedGame.Description);
            }

            Console.WriteLine("Готово");
            Console.ReadLine();
        }

        static public void AddNewHero()
        {
            Dictionary<int, string> availableCharacters = AvailableCharacters();
            Dictionary<int, string> availableRoles = AvailableRoles();
            Dictionary<int, string> availableItems = AvailableItems();

            Hero firstHero = savedGame.HeroInfo[0];

            Console.WriteLine("Кого добавляем?");

            foreach (var item in availableCharacters)
            {
                Console.WriteLine($"{item.Key}. {item.Value}");
            }

            Hero newHero = new Hero(firstHero);
            newHero.Id = int.Parse(Console.ReadLine());

            Console.WriteLine("Какой класс?");
            foreach (var item in availableRoles)
            {
                Console.WriteLine($"{item.Key}. {item.Value}");
            }

            newHero.RoleId = int.Parse(Console.ReadLine());

            int xp = 0;
            foreach(AvailableXP currentAvailableXP in firstHero.AvailableXP)
            {
                xp += currentAvailableXP.XP;
            }
            
            AvailableXP availableXP = new AvailableXP(newHero.RoleId, xp);
            newHero.AvailableXP = new AvailableXP[] { availableXP };

            Console.WriteLine("Какое снаряжение?");
            foreach (var item in availableItems)
            {
                Console.WriteLine($"{item.Key}. {item.Value}");
            }

            newHero.HeroItemIds = Console.ReadLine().Split(',').Select(x => int.Parse(x)).ToArray();

            savedGame.AddHero(newHero);
        }

        static public void RemoveHero()
        {
            Dictionary<int, string> availableCharacters = AvailableCharacters();

            Console.WriteLine("Кого удаляем?");

            for(int i = 0; i < savedGame.HeroInfo.Count; i++)
            {
                Console.WriteLine($"{i}. {availableCharacters[savedGame.HeroInfo[i].Id]}");
            }
            
            int id = int.Parse(Console.ReadLine());

            savedGame.RemoveHero(savedGame.HeroInfo[id]);
        }

        static public Dictionary<int, string> AvailableItems()
        {
            Dictionary<int, string> availableItems = new Dictionary<int, string>();

            availableItems.Add(1, "Боевой топор 2");
            availableItems.Add(5, "Кинжал 1");
            availableItems.Add(13, "Длинный лук 2");
            availableItems.Add(17, "Посох 2");
            availableItems.Add(21, "Меч 1");
            availableItems.Add(27, "Арфа 1");
            availableItems.Add(30, "Знамя 1");
            availableItems.Add(37, "Кольчуга");
            availableItems.Add(43, "Дорожная одежда");
            availableItems.Add(49, "Плащ");
            availableItems.Add(101, "Секира 1");
            availableItems.Add(105, "Рог 1");
            availableItems.Add(109, "Щит 1");
            availableItems.Add(113, "Праща 1");
            availableItems.Add(117, "Молот 2");
            availableItems.Add(121, "Трость 1");
            availableItems.Add(125, "Нож 1");           

            return availableItems;
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
