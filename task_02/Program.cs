using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Задание: Лучший преподаватель
// В учебном заведении проводится анкетирование студентов разных групп по качеству работы преподавателей. 
// По результатам анкеты каждого студента с несколькими вопросами в двухмерный массив записывается вещественное число - среднее значение балла по преподавателю. 
// Двухмерный массив типа double [N, M], где N - количество преподавателей, M - количество студентов. M и N не более 1000. Оценки в массиве в интервале от 0 до 5 включительно.
// Необходимо разработать функцию, которая ищет лучшего преподавателя - то есть, определяет номер строки массива, в которой среднее по всем значениям максимально. 
// Но для повышения объективности, мы самую высокую и самую низкую оценку по каждой строке исключаем из расчетов.
// Функция должна вернуть индекс строки в массиве и значение вычисленного среднего.

namespace task_02
{
    class Program
    {
        static double GetScore(double[,] arrMarks, int i)
        {
            var sum = 0d;
            var len = arrMarks.GetUpperBound(1) + 1;

            double max_value = 0d, min_value = 5d;
            int max_count = 0, min_count = 0;

            for (var j = 0; j < len; ++j)
            {
                if (arrMarks[i, j] == max_value)
                {
                    ++max_count;
                }
                else if (arrMarks[i, j] > max_value)
                {
                    max_count = 1;
                    max_value = arrMarks[i, j];
                }

                if (arrMarks[i, j] == min_value)
                {
                    ++min_count;
                }
                else if (arrMarks[i, j] < min_value)
                {
                    min_count = 1;
                    min_value = arrMarks[i, j];
                }

                sum += arrMarks[i, j];
            }

            if (max_value != min_value)
            {
                sum -= max_value * max_count + min_value * min_count;
                len -= max_count + min_count;
            }

            return sum / len;
        }

        static int[] GetBestProfs(double[,] arrMarks, out double score)
        {
            score = -1;
            int[] profs = { };

            var n = arrMarks.GetUpperBound(0) + 1;

            for (var i = 0; i < n; ++i)
            {
                var temp = GetScore(arrMarks, i);

                if (temp > score)
                {
                    score = temp;
                    profs = new int[] { i };
                }
                else if (temp == score)
                {
                    var my = new int[profs.Length + 1];

                    var j = 0;
                    for (; j < profs.Length; j++)
                    {
                        my[j] = profs[j];
                    }

                    my[j] = i;
                    profs = my;
                }
            }

            return profs;
        }

        static void Main(string[] args)
        {
            double[,] arrMarks = 
            {
                { 3.6, 3.1, 2.8, 1, 4, 3.3, 3.2, 3 },
                { 3.5, 3.6, 4.1, 3.9, 3.5, 5, 4, 5 },
                { 2.2, 2.7, 3.1, 3, 4.5, 2.2, 3.1, 3.7 },
                { 4.2, 3.4, 3, 4.3, 4.1, 4.6, 4.4, 4.5 },
                { 4.7, 4.1, 3.6, 2.1, 2.7, 2, 2.5, 2.7 }
            };

            var profs = GetBestProfs(arrMarks, out double score);
            Console.WriteLine($"profs: {string.Join(", ", profs)}; score: {score}");

            Console.ReadKey();
        }
    }
}
