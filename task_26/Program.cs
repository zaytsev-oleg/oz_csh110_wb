using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_26
{
    // Задание: Восемь ферзей
    // Дана шахматная доска размеров 8 на 8. 
    // Необходимо составить функцию, которая бы расставляла на доске 8 ферзей, но так, чтобы ни один из них не находился под угрозой.

    class Program
    {
        static int[,] GetBoard(int n)
        {
            var board = new int[n, n];
            return board;
        }

        static void IncreaseRow(int[,] matrix, int row, int val)
        {
            for (var i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[row, i] <= 0)
                    matrix[row, i] += val;
            }
        }

        static void IncreaseColumn(int[,] matrix, int col, int val)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] <= 0)
                    matrix[i, col] += val;
            }
        }

        static void IncreaseDiagonals(int[,] matrix, int row, int col, int val)
        {
            // Главная диагональ
            var k = 1;

            while (row - k >= 0 && col - k >= 0)
            {
                if (matrix[row - k, col - k] <= 0)
                    matrix[row - k, col - k] += val;

                k++;
            }

            k = 1;

            while (row + k < matrix.GetLength(0) && col + k < matrix.GetLength(1))
            {
                if (matrix[row + k, col + k] <= 0)
                    matrix[row + k, col + k] += val;

                k++;
            }

            // Второстепенная диагональ
            k = 1;

            while (row + k < matrix.GetLength(0) && col - k >= 0)
            {
                if (matrix[row + k, col - k] <= 0)
                    matrix[row + k, col - k] += val;

                k++;
            }

            k = 1;

            while(row - k >= 0 && col + k < matrix.GetLength(1))
            {
                if (matrix[row - k, col + k] <= 0)
                    matrix[row - k, col + k] += val;

                k++;
            }
        }

        static void Lock(int[,] board, int row, int col)
        {
            IncreaseRow(board, row, -1);
            IncreaseColumn(board, col, -1);
            IncreaseDiagonals(board, row, col, -1);
        }

        static void Unlock(int[,] board, int row, int col)
        {
            IncreaseRow(board, row, 1);
            IncreaseColumn(board, col, 1);
            IncreaseDiagonals(board, row, col, 1);
        }

        // Легенда:
        // 0   - свободная ячейка,
        // < 0 - заблокированная ячейка,
        // > 0 - ферзь

        static bool SetFigures(int[,] board, int n)
        {
            if (n == 0)
                return true;

            for (var i = 0; i < board.GetLength(0); i++)
            {
                for (var j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 0)
                    {
                        board[i, j] = n;

                        Lock(board, i, j);
                        var res = SetFigures(board, n - 1);
                        Unlock(board, i, j);

                        if (res)
                            return true;

                        board[i, j] = 0;
                    }
                }
            }

            return false;
        }

        static void Print(int[,] board)
        {
            for (var i = 0; i < board.GetLength(0); i++)
            {
                for (var j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{board[i, j], 3}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write($"{board[i, j], 3}");
                    }
                }

                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            const int n = 8;
            var board = GetBoard(n);

            var res = SetFigures(board, 8);

            if (res)
                Print(board);
            else
                Console.WriteLine("No answer!");

            Console.ReadKey();
        }
    }
}
