using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_20
{
    // В двухмерном квадратном массиве размера n находятся символы.
    // Напишите подпрограмму, которая выполняет в этом массиве поиск строки методом Рабина-Карпа.При этом строка может быть записана в массиве как по горизонтали, так и по вертикали.

    class Program
    {
        static int GetHash(char[] symbols)
        {
            var hash = 0;

            for (var i = 0; i < symbols.Length; i++)
                hash += symbols[i];

            return hash;
        }

        static bool Compare(char[] arr1, char[] arr2)
        {
            if (arr1.Length != arr2.Length)
                return false;

            var res = true;

            for (var i = 0; res && i < arr1.Length; i++)
                res = arr1[i] == arr2[i];

            return res;
        }

        static char[] RowExtract(char[,] arr, int row, int col, int len)
        {
            var res = new char[len];

            for (var i = 0; i < len; i++)
                res[i] = arr[row, col + i];

            return res;
        }

        static char[] ColExtract(char[,] arr, int row, int col, int len)
        {
            var res = new char[len];

            for (var i = 0; i < len; i++)
                res[i] = arr[row + i, col];

            return res;
        }

        static bool FindStr(char[,] arr, char[] str, out int row, out int col)
        {
            row = col = -1;

            var len = str.Length;
            var h1  = GetHash(str);

            // i - строка, j - столбец
            for (var i = 0; i < arr.GetLength(0); i++)
            {
                var h2 = -1;

                for (var j = 0; j <= arr.GetLength(1) - len; j++)
                {
                    if (j == 0)
                    {
                        h2 = GetHash(RowExtract(arr, i, 0, len));
                    }
                    else
                    {
                        h2 = h2 - arr[i, j - 1] + arr[i, j + len - 1];
                    }

                    if (h1 == h2)
                    {
                        if (Compare(str, RowExtract(arr, i, j, len)))
                        {
                            row = i;
                            col = j;

                            return true;
                        }
                    }
                }
            }

            // i - столбец, j - строка
            for (var i = 0; i < arr.GetLength(1); i++)
            {
                var h2 = -1;

                for (var j = 0; j <= arr.GetLength(0) - len; j++)
                {
                    if (j == 0)
                    {
                        h2 = GetHash(ColExtract(arr, j, i, len));
                    }
                    else
                    {
                        h2 = h2 - arr[j - 1, i] + arr[j + len - 1, i];
                    }

                    if (h1 == h2)
                    {                     
                        if (Compare(str, ColExtract(arr, j, i, len)))
                        {
                            row = j;
                            col = i;

                            return true;
                        }
                    }
                }
            }

            return false;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            char[,] arr =
            {
                { 'а', 'п', 'е', 'ш', 'с', 'к', 'р', 'о' },
                { 'х', 'о', 'з', 'в', 'о', 'л', 'к', 'у' },
                { 'э', 'ч', 'а', 'ш', 'ц', 'и', 'л', 'а' },
                { 'з', 'н', 'я', 'г', 'о', 'с', 'д', 'а' },
                { 'х', 'ц', 'ц', 'ф', 'ч', 'а', 'о', 'а' },
                { 'к', 'о', 'а', 'л', 'п', 'т', 'а', 'в' },
                { 'о', 'к', 'г', 'н', 'а', 'р', 'а', 'т' },
                { 'к', 'р', 'о', 'т', 'а', 'в', 'с', 'к' },
            };

            int row, col;

            if (FindStr(arr, "заяц".ToArray(), out row, out col))
            {
                Console.WriteLine($"Result: row = {row}, col = {col}");
            }
            else
            {
                Console.WriteLine("Result: not found!");
            }

            Console.ReadKey();
        }
    }
}
