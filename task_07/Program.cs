using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_07
{
    // Задание: Составить число
    // Необходимо определить, можно ли из единицы получить некоторое число num(тип uint), только с помощью операций «Прибавить a» и «Умножить на b». 
    // Числа a и b тоже типа uint. Последовательность операций надо вывести пользователю.
    // Если число соствит невозможно, должно быть выведено соответствующее сообщение.
    // 
    // Тестовые данные:
    // Входные: num = 25; a = 3; b = 4
    // Выходные: 1 *4 *4 +3 +3 +3

    class Program
    {
        static string Calc(int a, int b, int res, int @base = 1, string log = null)
        {
            if (log == null)
                log = $"{@base}";

            if (@base > res)
                return null;

            if (@base == res)
                return log += $" = {res}";

            return Calc(a, b, res, @base * b, $"{log} * {b}") ?? Calc(a, b, res, @base + a, $"{log} + {a}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Calc(3, 4, 8) ?? "NULL"); // 1 * 4 * 4 + 3 + 3 + 3 = 25
            Console.ReadKey();
        }
    }
}
