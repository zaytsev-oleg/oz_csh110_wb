using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_08
{
    // Задание: Поиск в двухмерном массиве
    // Дан двухмерный массив элементов типа int. Элементы в массиве отсортированы по возрастанию от [0, 0] до [n, n], по строкам.
    // Необходимо написать функцию, которая ищет в массиве число num используя принцип двоичного поиска.

    class Program
    {
        static bool Find(int[,] arr, int el, out int row, out int col)
        {
            var m = arr.GetLength(0) - 1;
            var n = arr.GetLength(1) - 1;

            var l = 0;
            var r = m;
            
            int i = -1;

            // ищем строку
            while(l <= r)
            {
                var mid = l + (r - l) / 2;

                if (arr[mid, 0] <= el && arr[mid, n] >= el)
                {
                    i = mid;
                    break;
                }

                if (arr[mid, 0] > el)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }

            if (i == -1)
            {
                row = col = -1;
                return false;
            }

            l = 0;
            r = n;

            // ищем элемент
            while(l <= r)
            {
                var mid = l + (r - l) / 2;

                if (arr[i, mid] == el)
                {
                    row = i;
                    col = mid;

                    return true;
                }

                if (arr[i, mid] > el)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }

            row = col = -1;
            return false;
        }

        static void Main(string[] args)
        {
            int[,] arr =
            {
                { 01, 02, 03, 04, 05 },
                { 06, 07, 08, 09, 10 },
                { 11, 12, 13, 14, 15 },
                { 16, 17, 18, 19, 20 },
            };

            int row, col;
            var el = 17;
            
            if (Find(arr, el, out row, out col))
            {
                Console.WriteLine($"{el}: row = {row}, col = {col}");
            }
            else
            {
                Console.WriteLine($"{el}: not found");
            }

            Console.ReadKey();
        }
    }
}
