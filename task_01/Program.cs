using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Задание: Циклический сдвиг
// В функцию передается одномерный массив типа int произвольного размера и shift - значение сдвига. 
// Функция должна сдвинуть значения элементов массива вправо или влево на shift позиций, при этом соблюдая принцип закольцованности элементов, 
// т.е. при сдвиге вправо на 1 позицию последний элемент массива становится первым.  

namespace task_01
{
    class Program
    {
        static void ShiftRight(int[] arr, int shift)
        {
            var len = arr.Length;
            shift   = shift % len;

            var arr2 = new int[shift];

            for (var i = 0; i < shift; ++i)
            {
                arr2[i] = arr[len - shift + i];
            }

            for (var i = 0; i < len;)
            {
                for (var j = 0; j < shift; ++j)
                {
                    var temp = arr[i];
                    arr[i]   = arr2[j];
                    arr2[j]  = temp;

                    if (++i == len)
                        break;
                }
            }
        }

        static void ShiftLeft(int[] arr, int shift)
        {
            var len = arr.Length;
            shift   = shift % len;

            var arr2 = new int[shift];

            for (var i = 0; i < shift; ++i)
            {
                arr2[i] = arr[i];
            }

            for (var i = 0; i < len;)
            {
                for (var j = 0; j < shift; ++j)
                {
                    var temp = arr[len - i - 1];
                    arr[len - i - 1] = arr2[shift - j - 1];
                    arr2[shift - j - 1] = temp;

                    if (++i == len)
                        break;
                }
            }
        }

        static void Shift(int[] arr, int shift)
        {
            if (shift > 0)
            {
                ShiftRight(arr, shift);
                return;
            }

            ShiftLeft(arr, -1 * shift);
        }

        static void Print(int[] arr)
        {
            Console.WriteLine($"{string.Join(", ", arr)}");
        }

        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };

            Print(arr);
            Shift(arr, 3);
            Print(arr);

            Console.ReadKey();
        }
    }
}
