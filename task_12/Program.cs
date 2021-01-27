using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_12
{
    // Задание: Ищем похожих
    // Объявите структуру SHuman, описывающую человека и включающую в себя поля "Фамилия”, ”Имя”, ”Отчество”, ”Год рождения”. 
    // На вход подпрограммы подается массив элементов данной структуры.
    // Напишите функцию, разбивающую этих людей на группы следующим образом - если у двух человек совпадает хотя бы одно поле, 
    // они попадают в одну группу(Владимир Семенович Высоцкий и Василий Васильевич Смыслов не имеют «общих» полей, 
    // но если в компании есть также Василий Семенович Лановой, то все трое попадут в одну группу). Порядок элементов в группах не важен.
    // Выберите оптимальный формат возвращаемого значения (как проще всего описать разбиение?).
    // При разработке алгоритма используйте класс List<>.
    
    class Program
    {
        struct SHuman : IEquatable<SHuman>
        {
            public string Surname;          // фамилия
            public string Firstname;        // имя
            public string Patronymic;       // отчество
            public int Year;                // год рождения

            public SHuman(string surname, string firstname, string patronymic, int year)
            {
                this.Surname = surname;
                this.Firstname = firstname;
                this.Patronymic = patronymic;
                this.Year = year;
            }

            public bool Equals(SHuman other)
            {
                return this.Surname == other.Surname || this.Firstname == other.Firstname || this.Patronymic == other.Patronymic || this.Year == other.Year;
            }

            public override string ToString()
            {
                return $"[{Surname} {Firstname} {Patronymic}, {Year}]";
            }
        }

        static void Insert(List<List<SHuman>> groups, SHuman el)
        {
            if (groups.Count == 0)
            {
                groups.Add(new List<SHuman> { el });
                return;
            }

            for (var i = 0; i < groups.Count; i++)
            {
                // пробуем вставить элемент в начало списка
                if(groups[i][0].Equals(el))
                {
                    var list = new List<SHuman> { el };
                    list.AddRange(groups[i]);
                    groups[i] = list;

                    // укрупнение: пробуем присоединить список i к любому другому списку из groups
                    for (var j = 0; j < groups.Count; j++)
                    {
                        if (j == i) continue;

                        var n = groups[j].Count;
                        
                        if (groups[j][n - 1].Equals(el))
                        {
                            groups[j].AddRange(groups[i]);
                            groups.RemoveAt(i);
                            return;
                        }
                    }

                    return;
                }

                var len = groups[i].Count;

                if (len > 1)
                {
                    // пробуем вставить элемент в конец списка
                    if (groups[i][len - 1].Equals(el))
                    {
                        groups[i].Add(el);

                        // укрупнение: пробуем присоединить к списку i любой другой список из groups
                        for (var j = 0; j < groups.Count; j++)
                        {
                            if (j == i) continue;

                            if (groups[j][0].Equals(el))
                            {
                                groups[i].AddRange(groups[j]);
                                groups.RemoveAt(j);
                                return;
                            }
                        }

                        return;
                    }
                    
                    if (len > 3)
                    {
                        // пробуем вставить элемент в середину списка (между двух смежных элементов)
                        for (var j = 1; j < len - 2; j++)
                        {
                            if (groups[i][j].Equals(el) && groups[i][j + 1].Equals(el))
                            {
                                var next = groups[i][j + 1];
                                groups[i][j + 1] = el;

                                for (var k = j + 2; k < len; k++)
                                {
                                    var temp = groups[i][k];
                                    groups[i][k] = next;
                                    next = temp;
                                }

                                groups[i].Add(next);
                                return;
                            }
                        }
                    }
                }
            }

            // создаём новый список и добавляем в него элемент
            groups.Add(new List<SHuman> { el });
        }

        static void Print(List<List<SHuman>> groups)
        {
            foreach (var group in groups)
            {
                foreach (var item in group)
                {
                    Console.WriteLine($"{item}");
                }

                Console.WriteLine(new string('=', 40));
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            SHuman[] humans = 
            {
                new SHuman("Пушкин",    "Александр", "Сергеевич",  1799),
                new SHuman("Ломоносов", "Михаил",    "Васильевич", 1711),
                new SHuman("Тютчев",    "Фёдор",     "Иванович",   1803),
                new SHuman("Суворов",   "Александр", "Васильевич", 1729),
                new SHuman("Менделеев", "Дмитрий",   "Иванович",   1834),
                new SHuman("Ахматова",  "Анна",      "Андреевна",  1889),
                new SHuman("Володин",   "Александр", "Моисеевич",  1919),
                new SHuman("Мухина",    "Вера",      "Игнатьевна", 1889),
                new SHuman("Верещагин", "Петр",      "Петрович",   1834),
            };

            var groups = new List<List<SHuman>>();

            foreach (var human in humans)
            {
                Insert(groups, human);
            }

            Print(groups);

            Console.ReadKey();
        }
    }
}
