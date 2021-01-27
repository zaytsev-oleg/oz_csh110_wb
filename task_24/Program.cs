using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task_24
{
    // Задание: Монетки (жадные алгоритмы)
    // Входные данные: набор номиналов монеток(номинал - целые числа) и требуемая сумма(целое число). 
    // Функция должна из указанного набора монеток составить нужную сумму.Число монеток каждого номинала не ограничено.
    // Решить задачу методом жадного алгоритма.

    class Program
    {
        static bool Calc(Dictionary<int, int> wallet, int target, ref Dictionary<int, int> result)
        {
            // жадный алгоритм:
            // ищем монету с максимальным номиналом меньшим или равным target

            var note = -1;

            foreach (var key in wallet.Keys)
            {
                if (key <= target && key > note && wallet[key] > 0)
                    note = key;
            }

            // монета не найдена - выходим
            if (note == -1)
                return false;

            wallet[note]--; // уменьшаем на единицу количество монет с номиналом note в кошельке

            if (result.ContainsKey(note)) // обновляем результат
                result[note]++;
            else
                result[note] = 1;

            var delta = target - note; // остаток

            if (delta > 0)
            {
                var tempWallet = new Dictionary<int, int>(wallet); // запоминаем текущее состояние кошелька
                var tempResult = new Dictionary<int, int>(result); // запоминаем текущий результат

                var res = Calc(wallet, delta, ref result); // пробуем собрать остаток

                // в случае неудачи обновляем кошелёк (tempWallet) и результат (tempResult) и перезапускаем расчёт с обновлёнными данными
                if (!res)
                {
                    // выбрасываем все монеты с номиналом note из tempWallet
                    tempWallet.Remove(note);

                    // уменьшаем на 1 количество монет с номиналом note в tempResult и при необходимости удаляем элемент с ключом note из tempResult
                    tempResult[note]--;
                    
                    if (tempResult[note] == 0)
                        tempResult.Remove(note);
                
                    // восстанавливаем результат
                    result = tempResult;

                    // перезапускаем расчёт для target
                    return Calc(tempWallet, target, ref result);
                }
            }

            return true;
        }

        static void Print(Dictionary<int, int> dict)
        {
            foreach (var item in dict)
                Console.WriteLine($"{item.Key} коп ({item.Value} шт)");
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // кошелёк
            var wallet = new Dictionary<int, int>
            {
                { 1,  1 }, // номинал + количество монет
                { 2,  0 },
                { 3,  5 },
                { 4,  0 },
                { 5,  5 },
                { 6,  0 },
                { 7,  2 },
                { 8,  0 },
                { 9,  0 },
                { 10, 0 },
                { 25, 0 },
                { 50, 0 },
            };

            var calc = new Dictionary<int, int>();
            var res = Calc(wallet, 35, ref calc);

            if (res)
                Print(calc);
            else
                Console.WriteLine("No items!");

            Console.ReadKey();
        }
    }
}
