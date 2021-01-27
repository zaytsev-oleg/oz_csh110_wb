using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_05
{
    // Задание: Список файлов
    // Разработайте функцию, которая по адресу папки выводит на экран список всех файлов в этой папке и из всех ее подпапках. Для решения задачи примените рекурсивный подход.
    // Используйте пространство имен System.IO (классы Directory и Path) для получения информации о папках и подпапках.
    // Оцениваться будет в том числе удобство восприятия иерархической структуры пользователем. При необходимости используйте псевдографику и цвет текста.
    // Обработку ошибок можно не делать.
    
    class Program
    {
        static void GetFiles(string path, int i = 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{new string(' ', i)}+ {(i > 0 ? new DirectoryInfo(path).Name : path)}");
            Console.ResetColor();

            i += 2;

            foreach (var file in Directory.GetFiles(path))
            {
                Console.WriteLine($"{new string(' ', i)}∟ {Path.GetFileName(file)}");
            }

            foreach(var dir in Directory.GetDirectories(path))
            {
                GetFiles(dir, i);
            }
        }

        static void Main(string[] args)
        {
            var path = @"C:\Program Files\dotnet";
            GetFiles(path);

            Console.ReadKey();
        }
    }
}
