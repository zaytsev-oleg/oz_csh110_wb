using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_19
{
    // Задание: Шифровка текста
    // Есть множество различных шифровок текста. Запрограммируем один из них.
    // Дано: подстановочная таблица в соответствии с которой буквы заменяются на двухзначные числа.
    // Принцип замены: если буква встречается в тексте первый раз, то она заменяется числом из первой строки, второй раз - из второй, третий раз - из третьей. четвертый раз - первой строки и т.д.
    // Сама таблица прилагается в виде файла.
    // Для простоты будет работать только с текстом из заглавных английских букв, пробела, точки и запятой. Итого у нас 87 различных кодов, от 1 до 87.
    // Напишите функцию шифровки (получает строку и подстановочную таблицу (подумайте о ее формате), возвращает строку. И функцию дешифровки.
    
    class Program
    {
        private static readonly char[] m_symbols = 
            { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', ' ', '.', ',' };

        private static readonly int[,] m_codes = 
        {
            { 61, 50, 26, 69, 11, 31, 17, 52, 65, 59, 60, 57, 27, 41, 07, 32, 15, 51, 14, 21, 42, 40, 87, 66, 44, 13, 53, 77, 79 },
            { 04, 54, 63, 12, 37, 72, 01, 70, 47, 81, 28, 55, 82, 67, 24, 76, 62, 74, 64, 35, 48, 75, 86, 18, 25, 84, 30, 19, 39 },
            { 45, 02, 56, 05, 78, 23, 73, 38, 08, 03, 46, 36, 09, 34, 16, 80, 58, 68, 20, 10, 22, 33, 06, 83, 29, 49, 71, 85, 43 },
        };

        struct Encoder
        {
            public Encoder(char[] symbols, int[,] codes)
            {
                this.Codes  = new Dictionary<char, List<int>>(symbols.Length);
                this.Counts = new Dictionary<char, int>(symbols.Length);

                for (var i = 0; i < symbols.Length; i++)
                {
                    var list = new List<int>();

                    for (var j = 0; j < codes.GetLength(0); j++)
                    {
                        list.Add(codes[j, i]);
                    }

                    this.Codes[symbols[i]]  = list;
                    this.Counts[symbols[i]] = 0;
                }
            }

            private Dictionary<char, List<int>> Codes { get; }
            private Dictionary<char, int> Counts { get; }

            public int Encode(char symbol)
            {
                var j = this.Counts[symbol] % this.Codes[symbol].Count;
                ++this.Counts[symbol];

                return this.Codes[symbol][j];
            }

            public void ResetCounts()
            {
                foreach (var key in this.Counts.Keys)
                {
                    this.Counts[key] = 0;
                }
            }
        }

        struct Decoder
        {
            public Decoder(char[] symbols, int[,] codes)
            {
                this.Codes  = new Dictionary<int, char>(codes.Length);

                for (var i = 0; i < symbols.Length; i++)
                {
                    for (var j = 0; j < codes.GetLength(0); j++)
                    {
                        this.Codes[codes[j, i]] = symbols[i];
                    }
                }
            }

            private Dictionary<int, char> Codes { get; }

            public char Decode(int code)
            {
                return this.Codes[code];
            }
        }

        static int[] Encode(string str)
        {
            var encoder = new Encoder(m_symbols, m_codes);
            var res  = new List<int>();

            foreach(var c in str)
            {
                res.Add(encoder.Encode(c));
            }

            return res.ToArray();
        }

        static string Decode(int[] codes)
        {
            var decoder = new Decoder(m_symbols, m_codes);
            var sb = new StringBuilder();

            foreach(var code in codes)
            {
                sb.Append(decoder.Decode(code));
            }

            return sb.ToString();
        }

        static void Print<T>(IEnumerable<T> seq, string separator = "")
        {
            Console.WriteLine(string.Join(separator, seq));
        }

        static void Main(string[] args)
        {
            // A   B   C   D   E   F   G   H   I   J   K   L   M   N   O   P   Q   R   S   T   U   V   W   X   Y   Z       .   ,
            // 61  50  26  69  11  31  17  52  65  59  60  57  27  41  07  32  15  51  14  21  42  40  87  66  44  13  53  77  79
            // 04  54  63  12  37  72  01  70  47  81  28  55  82  67  24  76  62  74  64  35  48  75  86  18  25  84  30  19  39
            // 45  02  56  05  78  23  73  38  08  03  46  36  09  34  16  80  58  68  20  10  22  33  06  83  29  49  71  85  43

            var str = "YOU CAN ASSIGN DIFFERENT VALUES TO ANY VARIABLE YOU DECLARE.";
            Print(str);

            var codes = Encode(str);
            Print(codes, " ");

            var res = Decode(codes);
            Print(res);

            Console.ReadKey();
        }
    }
}
