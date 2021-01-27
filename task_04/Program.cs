using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Задание: N - буквенные слова
// Разработать программу, которая вводит натуральные числа M и N (M<=33),  и выводит все N-буквенные слова, состоящие из первых M букв русского алфавита. 
// Например, при N=3 и М=4 программа должна вывести 64 слова: ААА, ААБ, ААВ, ..., ГГВ, ГГГ(порядок слов может быть и иным).
// Задачу решить двумя способами:
// 1) С применением рекурсии
// 2) Без применения рекурсии
// Рекомендуется использовать массив из букв русского алфавита.

namespace task_04
{
    class Program
    {
        // С применением рекурсии
        static void GetWords(int[] indices, char[] letters, ref int total)
        {
            var str = string.Empty;
            var inc = 0;

            for (var i = 0; i < indices.Length; ++i)
            {
                str += letters[indices[i]];

                if (inc == 0)
                {
                    if (indices[i] < letters.Length - 1)
                    {
                        inc = 1;
                        ++indices[i];
                    }
                    else
                    {
                        indices[i] = 0;
                    }
                }
            }

            Console.WriteLine(str);
            ++total;

            if (inc > 0)
            {
                GetWords(indices, letters, ref total);
            }
        }

        // Без применения рекурсии
        static int GetWords2(char[] letters, int n)
        {
            var total = 0;
            var indices = new int[n];

            int inc;

            do
            {
                ++total;

                var str = string.Empty;
                inc = 0;

                for (var i = 0; i < indices.Length; ++i)
                {
                    str += letters[indices[i]];

                    if (inc == 0)
                    {
                        if (indices[i] < letters.Length - 1)
                        {
                            inc = 1;
                            ++indices[i];
                        }
                        else
                        {
                            indices[i] = 0;
                        }
                    }
                }

                Console.WriteLine(str);
            } while (inc > 0);

            return total;
        }

        static void Main(string[] args)
        {
            var n = 3;
            var m = 4;

            // АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ
            var letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Substring(0, m).ToArray();

            int total = 0;
            //GetWords(new int[n], letters, ref total);
            total = GetWords2(letters, n);

            Console.WriteLine($"total: {total}");

            Console.ReadKey();
        }
    }
}
