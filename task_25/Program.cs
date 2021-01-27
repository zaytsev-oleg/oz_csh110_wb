using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_25
{
    // Задание: Поиск пути в лабиринте(волновой алгоритм)
    // На вход подается двухмерный массив, который представляет лабиринт. Типы ячеек - int, занятые ячейки кодируем числом -1.
    // Также входными данными являются стартовая ячейка А и конечная ячейка Б в массиве.
    // Необходимо использую волновой алгоритм (алгоритм Ли) найти кратчайший путь из точки А в точку Б.

    class Program
    {
        // Легенда:
        //  0 - пустая ячейка,
        // -1 - барьер,
        // -2 - старт,
        // -4 - финиш,
        // -3 - элемент маршрута

        const int Empty   =  0;
        const int Barrier = -1;
        const int Start   = -2;
        const int Finish  = -4;
        const int Route   = -3;

        static int[,] GetMatrix()
        {
            int[,] matrix =
            {
                {  0, -1,  0, -1,  0, -1,  0,  0,  0,  0,  0,  0 },
                {  0,  0,  0, -1,  0, -1,  0,  0,  0, -1, -1,  0 },
                {  0, -1,  0, -1, -1, -1,  0,  0,  0, -1, -1,  0 },
                { -2, -1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0 },
                {  0, -1,  0,  0,  0,  0,  0,  0, -1,  0,  0,  0 },
                {  0,  0,  0,  0,  0, -1,  0,  0, -1,  0,  0, -1 },
                {  0, -1,  0,  0,  0, -1,  0,  0, -1, -1,  0,  0 },
                {  0, -1,  0,  0,  0,  0,  0,  0,  0, -1,  0,  0 },
                {  0, -1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0 },
                {  0, -1, -1, -1,  0,  0,  0,  0,  0, -1, -1,  0 },
                {  0, -1, -1, -1,  0,  0,  0,  0,  0,  0,  0, -4 },
            };

            return matrix;
        }

        static ValueTuple<int, int> Find(int[,] matrix, int value)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == value)
                        return ValueTuple.Create(i, j);
                }
            }

            throw new FormatException($"Value of {value} was not found!");
        }

        static bool FindRoute(int[,] matrix, bool interim = false)
        {
            var start  = Find(matrix, Start);
            var finish = Find(matrix, Finish);

            var val = 1;
            SetValue(matrix, val, start.Item1, start.Item2);
            
            // заполняем матрицу
            while (FindAndSet(matrix, val++));

            if (interim)
            {
                Console.WriteLine(new string('-', 10));
                Console.WriteLine("Interim:");
                Print(matrix);
            }

            // ищем оптимальный маршрут
            var row = finish.Item1;
            var col = finish.Item2;

            var min = matrix.Length;

            while(1 == 1)
            {
                int x = -1, y = -1;

                if (row - 1 >= 0 && (matrix[row - 1, col] == Start || (matrix[row - 1, col] > 0 && matrix[row - 1, col] < min)))
                {
                    x = row - 1;
                    y = col;
                    min = matrix[x, y];
                }

                if (row + 1 < matrix.GetLength(0) && (matrix[row + 1, col] == Start || (matrix[row + 1, col] > 0 && matrix[row + 1, col] < min)))
                {
                    x = row + 1;
                    y = col;
                    min = matrix[x, y];
                }

                if (col - 1 >= 0 && (matrix[row, col - 1] == Start || (matrix[row, col - 1] > 0 && matrix[row, col - 1] < min)))
                {
                    x = row;
                    y = col - 1;
                    min = matrix[x, y];
                }

                if (col + 1 < matrix.GetLength(1) && (matrix[row, col + 1] == Start || (matrix[row, col + 1] > 0 && matrix[row, col + 1] < min)))
                {
                    x = row;
                    y = col + 1;
                    min = matrix[x, y];
                }

                // маршрут не существует - выходим
                if (x < 0)
                {
                    BackToNormal(matrix);
                    return false;
                }
                
                // маршрут найден - выходим
                if (min == Start)
                {
                    BackToNormal(matrix);
                    return true;
                }

                matrix[x, y] = Route;
                
                row = x;
                col = y;
            }
        }

        static bool FindAndSet(int[,] matrix, int val)
        {
            var res = false;

            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == val)
                    {
                        var setValue = SetValue(matrix, val + 1, i, j);
                        res = res || setValue;
                    }
                }
            }

            return res;
        }

        // проставляем значение val в окрестности ячейки [row, col]
        static bool SetValue(int[,] matrix, int val, int row, int col)
        {
            var res = false;

            if (row - 1 >= 0 && matrix[row - 1, col] == Empty)
            {
                matrix[row - 1, col] = val;
                res = true;
            }

            if (row + 1 < matrix.GetLength(0) && matrix[row + 1, col] == Empty)
            {
                matrix[row + 1, col] = val;
                res = true;
            }

            if (col - 1 >= 0 && matrix[row, col - 1] == Empty)
            {
                matrix[row, col - 1] = val;
                res = true;
            }

            if (col + 1 < matrix.GetLength(1) && matrix[row, col + 1] == Empty)
            {
                matrix[row, col + 1] = val;
                res = true;
            }

            return res;
        }

        static void BackToNormal(int[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                        matrix[i, j] = Empty;
                }
            }
        }

        static void Print(int[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == Start || matrix[i, j] == Finish)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (matrix[i, j] == Barrier)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (matrix[i, j] == Route)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }

                    Console.Write($"{matrix[i, j] + "", 3}");
                    Console.ResetColor();
                }

                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            var matrix = GetMatrix();
            
            Console.WriteLine("Initial:");
            Print(matrix);

            if (FindRoute(matrix, true))
            {
                Console.WriteLine(new string('-', 10));
                Console.WriteLine("Result:");
                Print(matrix);
            }
            else
            {
                Console.WriteLine(new string('-', 10));
                Console.WriteLine("Result: deadlock!");
            }

            Console.ReadKey();
        }
    }
}
