using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_31
{
    class Program
    {
        static int[] PrefixFunc(string str)
        {
            var len = str.Length;

            var pref = new int[len];
            pref[0] = 0;

            for (var i = 1; i < len; i++)
            {
                var pos = i / 2 + 1;
                
                while(pos <= i)
                {
                    var res = true;
                    
                    var j = 0;
                    for (; res && j <= i - pos; j++)
                    {
                        res = str[j] == str[pos + j];
                    }

                    if (res)
                    {
                        pref[i] = j;
                        pos = i + 1;
                    }
                    else
                    {
                        pos++;
                    }
                }
            }

            return pref;
        }

        static bool Find(string word, string str, out int k)
        {           
            k = -1;
            var pf = PrefixFunc(word);

            var lenW = word.Length;
            var lenS = str.Length;

            int i = 0, j = 0;

            for (; i < lenS - lenW + 1;)
            {
                Console.WriteLine(i);

                var res = true;

                while (res && j < lenW)
                {
                    res = word[j] == str[i + j];

                    if (res)
                        j++;
                }

                if (res)
                {
                    k = i;
                    return true;
                }
                else
                {
                    if (j == 0)
                    {
                        i++;
                    }
                    else
                    {
                        var pv = pf[j - 1];

                        if (pv == 0)
                        {
                            i += j;
                            j = 0;
                        }
                        else
                        {
                            i += j - pv;
                            j = pv;
                        }
                    }
                }
            }

            return false;
        }

        static void Main(string[] args)
        {
            var word = "ABCDABD";
            var str  = "ABC ABCDAB ABCDABCDABDE";

            // var word = "dde";
            // var str  = "abcdddefg";

            Console.WriteLine($"word: {word}");
            Console.WriteLine($"PrefixFunc({word}): {string.Join(", ", PrefixFunc(word))}");
            Console.WriteLine($"str: {str}");
            
            int k;
            Console.WriteLine($"{Find(word, str, out k)}, k = {k}");

            Console.ReadKey();
        }
    }
}
