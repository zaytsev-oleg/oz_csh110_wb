using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_16
{
    // Задание: Индексированный поиск файла
    // Задача: разработать приложение для более быстрого, индексированного поиска файлов по заданному пользователем имени.
    // Индексирование и поиск выполнять в пределах указанной пользователем папки и всех ее подпапках.

    // Шаг 1. Разработайте хеш-функцию для получения хеш-кода входной строки. Хеш-код предполагается - целое число в интервале от 0 до 255 (тип Byte).
    // Шаг 2. Разработайте функцию формирования хеш-таблицы со списками.Входной аргумент - имя стартовой папки.Результат работы - массив arrRes[0 - 255], каждый элемент которого типа List<..>
    // Шаг 3. Разработайте подпрограмму Main, которая обеспечивает пользовательский интерфейс и логику работы, аналогичную примеру-образцу.
    
    // Обязательное условие: при реализации всех указанных выше подпрограмм все нештатные ситуации нужно обрабатывать оператором TRY CATCH:
    //
    // Отсутствие хеш-кода указанного файла в хеш-таблице
    // Ввод пользователем неверного значения или неверного имени папки
    // Ошибки доступа к элементам файловой системы

    class Program
    {
        static int Length { get; } = 256;

        static int GetHashCode(string strS)
        {
            var res = 0;

            foreach (var c in strS)
                res += c;

            res %= Length;
            return res;
        }

        static List<string>[] Index(string path)
        {
            var res = new List<string>[Length];

            for (var i = 0; i < Length; i++)
            {
                res[i] = new List<string>();
            }

            Index(path, res);

            return res;
        }

        static void Index(string path, List<string>[] index)
        {
            foreach (var file in Directory.GetFiles(path))
            {
                var j = GetHashCode(Path.GetFileName(file));
                index[j].Add(file);
            }

            foreach (var dir in Directory.GetDirectories(path))
            {
                Index(dir, index);
            }
        }

        static List<string> Find(string file, List<string>[] index)
        {
            var res = new List<string>();
            var j = GetHashCode(file);

            foreach(var el in index[j])
            {
                if (file == Path.GetFileName(el))
                {
                    res.Add(el);
                }
            }

            if (res.Count == 0)
            {
                throw new FileNotFoundException();
            }

            return res;
        }

        static void Print(IEnumerable<string> list)
        {
            var i = 0;

            foreach (var item in list)
            {
                Console.WriteLine($"{++i}. {item}");
            }
        }

        static void Main(string[] args)
        {
            try
            {
                var index = Index(@"C:\Program Files\dotnet");
                var files = Find("mscorlib.dll", index);

                Print(files);
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine($"Error: FileNotFound!");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.GetBaseException().Message}");
            }

            Console.ReadKey();
        }
    }
}
