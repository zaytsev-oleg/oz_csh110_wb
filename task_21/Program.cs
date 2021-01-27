using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_21
{
    // Задание: Палиндром
    // Как известно, палиндром - это число или текст, который при прочтении слева направо или справа налево дает один и тот же результат.Известная фраза-палиндром:
    // "А роза упала на лапу Азора"
    // состоит из нескольких слов, разделенных пробелами.
    // Необходимо написать функцию, которой подается на вход строка состоящая из 1 или более слов (разделитель - пробел). Определить является ли она палиндромом.
    // Вероятно необходимо сначала преобразовать строку к определенному регистру, убрать все пробелы и далее сделать проверку на принадлежность палиндрому.
    
    class Program
    {
        static bool IsPalindrom(string str)
        {
            str = str.Replace(" ", "").ToUpper();
            var len = str.Count();

            var res = true;

            for (var i = 0; res && i < len / 2; i++)
                res = str[i] == str[len - 1 - i];

            return res;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var str = "А роза упала на лапу Азора";
            Console.WriteLine($"IsPalindrom = {IsPalindrom(str)}");

            Console.ReadKey();
        }
    }
}
