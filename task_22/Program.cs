using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_22
{
    // Задание: Составить слово
    // Функция должна во входной строке text искать слово word, при этом порядок символов в строке text является важным, но они не обязательно должны находится рядом.
    //
    // Пример 1. Истина
    // text = СТРОИТЕЛЬНЫЙ РОБОТ
    // word = ТОРТ
    // 
    // Пример 2. Ложь
    // text = ТЕМПЕРАТУРНЫЙ КОЛЛАПС
    // word = ТОРТ
    // 
    // Можно использовать итерационный или рекурсивный подход.
    
    class Program
    {
        static bool Find(string text, string word)
        {
            var lenT = text.Length;
            var lenW = word.Length;

            text = text.ToUpper();
            word = word.ToUpper();

            int i, j;
            i = j = 0;

            // условие цикла:
            // пока количество доступных символов text (lenT - i) больше или равно количества искомых символов word (lenW - j)
            
            while(lenT - i >= lenW - j)
            {
                if (text[i] == word[j])
                {
                    if (++j == lenW)
                        return true;
                }

                ++i;
            }

            return false;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Find("СТРОИТЕЛЬНЫЙ РОБОТ", "ТОРТ"));
            Console.WriteLine(Find("ТЕМПЕРАТУРНЫЙ КОЛЛАПС", "ТОРТ"));

            Console.ReadKey();
        }
    }
}
