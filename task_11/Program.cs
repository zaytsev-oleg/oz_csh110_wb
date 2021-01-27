using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_11
{
    // Задание: Ханойские башни
    // Реализуйте проект, который в автоматическом режиме решает известную головоломку Ханойские башни.
    // При реализации разработать рекурсивную подпрограмму, у которой предлагаются такие аргументы:
    // public static void Move(Башня_Откуда, Башня_Куда, Башня_Временная, Количество_Перекладываемых_Дисков)
    // Подумайте, каким образом эффективно и удобно запрограммировать три башни(спицы) с кольцами разного диаметра на них.

    class Program
    {
        static void Move(Stack<int> source, Stack<int> target, Stack<int> temp, int num)
        {
            if (num == 0)
                return;

            Move(source, temp, target, num - 1);
            target.Push(source.Pop());
            Move(temp, target, source, num - 1);
        }

        static void Main(string[] args)
        {
            var n = 15;

            var source = new Stack<int>(n);
            var target = new Stack<int>(n);
            var temp   = new Stack<int>(n);

            for (var i = 0; i < n; i++)
            {
                source.Push(n - i);
            }

            Move(source, target, temp, source.Count);

            Console.ReadKey();
        }
    }
}
