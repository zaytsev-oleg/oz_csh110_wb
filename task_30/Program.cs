using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_30
{
    // Иван Иванович катаясь на кольцевой ветке метрополитена записывал первые буквы станций в одномерный массив, начиная от первой станции на которой он начал свой маршрут и заканчивая последней станцией.
    // Петр Петрович выполнил аналогичную операцию. Но поскольку был немного не трезв, то возможно допустил ошибки при записи.
    // Необходимо разработать функцию, которая определяет, являются ли в двух массивах последовательности элементов идентичными или нет.
    // Размеры массивов считать не более 50. Первые буквы станций считать заглавными буквами английского алфавита.
    
    // Пример 1. Последовательности в массивах являются идентичными.
    // Массив 1:  G, T, U, W, G, A, O, K, T
    // Массив 2:  A, O, K, T, G, T, U, W, G
    
    // Пример 2. Последовательности в массивах не являются идентичными.
    // Массив 1:  G, T, U, W, G, A, O, K, T
    // Массив 2:  A, O, Z, T, G, T, U, A, G

    class Program
    {
        static bool Compare(char[] arr1, char[] arr2)
        {
            // 1. сравнение контрольных сумм
            int h1 = 0, h2 = 0;

            foreach (var el in arr1)
                h1 += el;

            foreach (var el in arr2)
                h2 += el;

            if (h1 != h2)
                return false;

            // 2. поэлементное сравнение
            var len = arr1.Length;

            for (var i = 0; i < len; i++)
            {
                if (arr2[i] == arr1[0])
                {
                    var res = true;

                    for (var j = 1; res && j < len; j++)
                    {
                        res = arr1[j] == arr2[(i + j) % len];
                    }

                    if (res)
                        return true;
                }
            }

            return false;
        }

        static void Main(string[] args)
        {
            char[] arr1 = { 'G', 'T', 'U', 'W', 'G', 'A', 'O', 'K', 'T' }; // Иван Иванович
            char[] arr2 = { 'A', 'O', 'K', 'T', 'G', 'T', 'U', 'W', 'G' }; // Петр Петрович

            char[] arr3 = { 'G', 'T', 'U', 'W', 'G', 'A', 'O', 'K', 'T' }; // Иван Иванович
            char[] arr4 = { 'A', 'O', 'Z', 'T', 'G', 'T', 'U', 'A', 'G' }; // Петр Петрович

            Console.WriteLine($"arr1 == arr2: {Compare(arr1, arr2)}");
            Console.WriteLine($"arr3 == arr4: {Compare(arr3, arr4)}");

            Console.ReadKey();
        }
    }
}
