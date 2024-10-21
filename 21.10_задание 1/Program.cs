using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21._10_задание_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var k = GetNumber("k");
            var m = GetNumber("m");
            var n = GetNumber("n");

            if (IsStatementTrue(k, m, n))
                Console.WriteLine("Утверждение истинно");
            else Console.WriteLine("Утверждение ложно");

            Console.ReadKey();
        }

        static bool IsStatementTrue(int k, int m, int n)
        {
            //число n не кратно ни двум, ни трем; все числа целые
            return n % 2 != 0 && n % 3 != 0;
        }
        
        static int GetNumber(string numberName)
        {
            Console.WriteLine($"Введите число {numberName}");
            return int.Parse(Console.ReadLine());
        }

    }
}
