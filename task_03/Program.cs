using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Задание: Сортировка методом пузырька
// На вход подается одномерный массив вещественных чисел. Необходимо отсортировать элементы в массиве по возрастанию методом пузырька.

namespace task_03
{
    class Program
    {
        static void Sort(int[] arr, int k)
        {
            var len = arr.Length;

            for (var i = 0; i < len - 1; ++i)
            {
                for (var j = i + 1; j < len; ++j)
                {
                    if (k * arr[i] > k * arr[j])
                    {
                        var temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }

        static void SortAsc(int[] arr)
        {
            Sort(arr, 1);
        }

        static void SortDesc(int[] arr)
        {
            Sort(arr, -1);
        }

        static void Main(string[] args)
        {
            int[] arr = { 1, 7, 4, 2, 5, 8, 9, 3, 6, 9, 1, 5 };
            
            Console.WriteLine($"{string.Join(", ", arr)}");
            SortAsc(arr);
            Console.WriteLine($"{string.Join(", ", arr)}");

            Console.ReadKey();
        }
    }
}
