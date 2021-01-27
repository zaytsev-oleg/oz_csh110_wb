using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_27
{
    // Задание: Отсортированный список строк
    // На вход подается строка - фраза, состоящая из отдельных слов(разделителями считать пробел или пробелы). 
    // Нужно сформировать список слов, которые идут там в порядке возрастания. Использовать класс List.
    // Не пользоваться встроенной функцией сортировки, вместо этого реализовать вставку очередного слова в нужное место в списке.

    class Program
    {
        static List<string> Sort(string str)
        {
            var words  = str.Split(new char[] { ' ', '.', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            var result = new List<string>(words.Length) { words[0] };

            for (var i = 1; i < words.Length; i++)
            {
                var word = words[i];
                var done = false;

                var j = 0;

                for (; !done && j < result.Count(); j++)
                {
                    if (word.CompareTo(result[j]) == -1)
                    {
                        result.Insert(j, word); //
                        done = true;
                    }
                }

                if (!done)
                    result.Insert(j, word);
            }

            return result;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var str  = "Было так сыро и туманно, что насилу рассвело; в десяти шагах, вправо и влево от дороги, трудно было разглядеть хоть что-нибудь из окон вагона";
            Console.WriteLine($"{str}:\n");

            var list = Sort(str);

            var i = 0;
            
            foreach (var item in list)
            {
                Console.WriteLine($"{++i}. {item}");
            }

            Console.ReadKey();
        }
    }
}
