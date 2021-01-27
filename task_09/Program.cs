using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task_09
{
    // Задание: Сортировка блинов
    // При выпечке небольших блинов на большой сковороде блины получаются разными по размеру(диаметру). Блины лежат стопочкой в том порядке, в каком выпекались.Необходимо отсортировать их по диаметру – чтобы самый большой был внизу.Делать это можно с помощью лопатки: воткнуть лопатку в любое место стопки блинов или под всю стопку и перевернуть всё, что на лопатке, на остаток стопки или на тарелку. Можно считать диаметр блина типа int.
    // Подумайте о выборе оптимального способа представления данных с помощью стандартных классов.Net: список, очередь, стек... (не массив)
    // Для выполнения переворота рекомендуется написать отдельную функцию.
    // Возможные наборы для тестирования:
    // 4, 1, 7, 3, 2, 4, 8, 5, 6
    // 1, 2, 3, 4, 4, 5, 6, 7, 8
    // 8, 7, 6, 5, 4, 4, 3, 2, 1

    class Program
    {
        static void Sort(List<int> items)
        {
            int max;

            for (var i = 0; i < items.Count - 1; i++)
            {
                max = GetMax(items, items.Count - i);

                if (max == items.Count - i - 1)
                {
                    continue;
                }

                if (max != 0)
                {
                    Transform(items, max);
                }

                Transform(items, items.Count - i - 1);
            }
        }

        static int GetMax(List<int> items, int count)
        {
            int max, index;

            max   = items[0];
            index = 0;

            for (var i = 1; i < count; i++)
            {
                if (items[i] > max)
                {
                    max   = items[i];
                    index = i;
                }
            }

            return index;
        }

        static void Transform(List<int> items, int index)
        {
            for (var i = 0; i < (index + 1) / 2; i++)
            {
                var temp = items[i];
                items[i] = items[index - i];
                items[index - i] = temp;
            }
        }

        static void Print(List<int> items)
        {
            Console.WriteLine(string.Join(" ", items));
        }

        static void Main(string[] args)
        {
            var items = new List<int> { 2, 3, 0, 5, 6, 1, 2, 9, 0, 7, 4 };
            
            Print(items);
            Sort(items);
            Print(items);

            Console.ReadKey();
        }
    }
}
