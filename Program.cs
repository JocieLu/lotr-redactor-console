using System;
using System.IO;

namespace lotr_redactor_console
{
    class Program
    {
        static void Main(string[] args)
        {
            string path;

            Console.WriteLine("путь к файлам игры:");
            path = Console.ReadLine();

            string[] files = Directory.GetFiles(path, "SavedGameA", SearchOption.AllDirectories);

            Console.ReadLine();


        }
    }
}
