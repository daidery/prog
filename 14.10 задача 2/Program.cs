using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14._10_задача_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "гардероб";
            var word1 = s
                .Remove(1, 2)
                .Remove(2, 1)
                .Remove(3, 2)
                .Remove(0, 1);
            word1 += s.Substring(1, 1);
            word1 += s.Substring(0, 2);

            var word2 = ReverseString(s)
                .Remove(1, 2)
                .Remove(4, 2);
            word2 += ReverseString(s)
                .Substring(1, 1);

            Console.WriteLine("Исходное слово - " + s);
            Console.WriteLine("Первое слово - " + word1);
            Console.WriteLine("Второе слово - " + word2);

            Console.ReadKey();
        }

        static string ReverseString(string s)
        {
            return new string(s.Reverse().ToArray());
        }
    }
}
