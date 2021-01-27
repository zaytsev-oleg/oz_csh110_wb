using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_28
{
    // Быстрая сортировка (сортировка Хоара)
    // Похоже на правду

    class Program
    {
        static void Sort(int[] arr)
        {
            Sort(arr, 0, arr.Length);
        }

        static void Sort(int[] arr, int start, int end)
        {
            if (start == end)
                return;

            var el = arr[start]; // опорный элемент
            var count = 0;

            for (var i = start + 1; i < end; i++)
            {
                if (arr[i] < el)
                {
                    var temp = arr[i];
                    arr[i]   = arr[start + count];
                    arr[start + count] = temp;

                    ++count;
                }
            }

            if (count == 0)
            {
                Sort(arr, start + 1, end);
            }
            else
            {
                Sort(arr, start, start + count);
                Sort(arr, start + count, end);
            }
        }

        static void Print<T>(IEnumerable<T> seq)
        {
            Console.WriteLine(string.Join(", ", seq));
        }

        static void Main(string[] args)
        {
            var arr = new int[] { 6, 8, 9, 7, 8, 0, 2, 5, 3, 4, 1, 5, 11 };

            Print(arr);
            Console.WriteLine(new string('-', 5));
            
            Sort(arr);
            Print(arr);

            Console.ReadKey();
        }
    }
}
