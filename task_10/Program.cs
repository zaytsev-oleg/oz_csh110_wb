using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_10
{
    // Задание: Массив случайных чисел
    // Напишите функцию, возвращающую линейный массив размером N , заполненный случайными целыми числами от 1 до N.
    // Необходимо чтобы каждое число из интервала[1, N] встречалось в массиве один и только один раз.

    class Program
    {
        static void Fill(int[] arr)
        {
            var len  = arr.Length;
            var list = new List<int>(len);

            for (var i = 0; i < len;)
            {
                list.Add(++i);
            }

            int j = 0;

            while(j < len)
            {
                var index = new Random().Next(0, len - j);
                arr[j++]  = list[index];
                list.RemoveAt(index);
            }
        }

        static void Print(int[] arr)
        {
            Console.WriteLine(string.Join(" ", arr));
        }

        static void Main(string[] args)
        {
            var arr = new int[10];

            Fill(arr);
            Print(arr);

            Console.ReadKey();
        }
    }
}
