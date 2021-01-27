using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_23
{
    // Задание: Проверка корректности
    // Написать функцию, которая определяет, является ли введённое слово (переменная string) идентификатором т.е.:
    // начинается ли оно с английской буквы в любом регистре или знака подчеркивания и не содержит других символов, 
    // кроме букв английского алфавита (в любом регистре), цифр и знака подчеркивания.

    class Program
    {
        static bool IsLetter(char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
        }

        static bool IsFigure(char c)
        {
            return c >= '0' && c <= '9';
        }

        static bool IsUnderscore(char c)
        {
            return c == '_';
        }

        static bool IsValid(string str)
        {
            var len = str.Length;
            var res = IsLetter(str[0]) || IsUnderscore(str[0]);

            for (var i = 1; res && i < len; i++)
                res = IsLetter(str[i]) || IsFigure(str[i]) || IsUnderscore(str[i]);

            return res;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(IsValid("_hElLo55_"));
            Console.WriteLine(IsValid("_hel%lo55_"));

            Console.ReadKey();
        }
    }
}
