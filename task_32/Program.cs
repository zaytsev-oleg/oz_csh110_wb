using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_32
{
    // Ref: https://en.wikipedia.org/wiki/Knuth%E2%80%93Morris%E2%80%93Pratt_algorithm
    class Program
    {
        // Jump table or Partial match table
        static int[] PartialMatchTable(string str)
        {
            var len = str.Length;
            
            var res = new int[len];
            res[0] = -1;

            var pos = 1;
            var cnd = 0;

            while (pos < len)
            {
                if (str[pos] == str[cnd])
                {
                    res[pos] = res[cnd];
                }
                else
                {
                    res[pos] = cnd;
                    cnd = res[cnd];

                    while (cnd >= 0 && str[pos] != str[cnd])
                        cnd = res[cnd];
                }

                pos++;
                cnd++;
            }

            return res;
        }

        // Search algorithm
        static int Find(string str, string word)
        {
            var pmt = PartialMatchTable(word);

            var j = 0;
            var k = 0;

            while(j < str.Length)
            {
                if (word[k] == str[j])
                {
                    j++;
                    k++;

                    if (k == word.Length)
                        return j - k;
                }
                else
                {
                    k = pmt[k];

                    if (k < 0)
                    {
                        j++;
                        k++;
                    }
                }
            }

            return -1;
        }

        static void Print<T>(IEnumerable<T> seq)
        {
            Console.WriteLine(string.Join(", ", seq));
        }

        static void Main(string[] args)
        {
            var word = "ABABACD";
            var res = PartialMatchTable(word);
            Print(res);

            Console.WriteLine(Find("ABABACD", "BA"));

            Console.ReadKey();
        }
    }
}
