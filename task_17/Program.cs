using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_17
{
    // Задание: Частотный словарь
    // Написать функцию, которая составляет частотный словарь слов в заданной строке.Частотный словарь – это массив или коллекция, в которой указаны все найденные в строке слова с количеством их появления.
    // Словом считать последовательность символов, разделенных пробелами.

    class Program
    {
        static Dictionary<string, int> Count(string str)
        {
            var res = new Dictionary<string, int>();

            foreach (var s in str.Split(' ', ',', '.'))
            {
                if (s == string.Empty)
                    continue;

                var key = s.ToUpper();

                if (res.ContainsKey(key))
                {
                    ++res[key];
                }
                else
                {
                    res.Add(key, 1);
                }
            }

            return res;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var str = "Пусть всегда будет солнце, пусть всегда будет мама, пусть всегда буду я";

            foreach (var item in Count(str))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            Console.ReadKey();
        }
    }
}
