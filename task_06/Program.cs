using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_06
{
    class Program
    {
        // Быстрая сортировка (она же сортировка Хоара), 
        // O(N*log2(N)) - среднее время работы, O(N^2) - худшее время работы, o(N) - лучшее время работы.

        static void QuickSort(int[] arr, int left, int right)
        {
            var l = left;
            var r = right;

            var pivot = arr[left];

            while (l <= r)
            {
                while (arr[l] < pivot) ++l;
                while (arr[r] > pivot) --r;

                if (l <= r)
                {
                    var temp = arr[l];
                    arr[l]   = arr[r];
                    arr[r]   = temp;

                    --r;
                    ++l;
                }
            }

            if (left < r)  QuickSort(arr, left, r);
            if (right > l) QuickSort(arr, l, right);
        }

        static void Main(string[] args)
        {
            int[] arr = { 7, 6, 5, 4, 3, 2, 1 };

            Console.WriteLine($"{string.Join(", ", arr)}");
            QuickSort(arr, 0, arr.Length - 1);
            Console.WriteLine($"{string.Join(", ", arr)}");

            Console.ReadKey();
        }
    }
}
