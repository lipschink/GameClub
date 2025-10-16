using System;
using System.Collections.Generic;
using System.IO;

namespace GameClub.Utils
{
    internal class FileExporter
    {
        public static void Export(string username, IEnumerable<string> history)
        {
            string path = $"{username}_history.txt";
            File.WriteAllLines(path, history);
            Console.WriteLine($"История пользователя {username} сохранена в файл: {path}");
        }
    }
}
