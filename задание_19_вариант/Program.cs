using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_19_вариант
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int target = 1729;
            int limit = 50;

            Dictionary<int, List<string>> sums = new Dictionary<int, List<string>>();

            for (int a = 1; a <= limit; a++)
            {
                for (int b = a; b <= limit; b++)
                {
                    int sum = a * a * a + b * b * b;

                    if (!sums.ContainsKey(sum))
                        sums[sum] = new List<string>();

                    sums[sum].Add($"{a}^3+{b}^3");
                }
            }

            foreach (var entry in sums)
            {
                if(entry.Key > target && entry.Value.Count == 2)
                {
                    Console.WriteLine($"Числом Рамануджана-Харди, следующим за 1729, является {entry.Key}");
                    Console.WriteLine("\nЕго представление в виде двух различных сумм кубов следующее:\n");
                    int i = 1;

                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;

                    foreach (var representation in entry.Value)
                    {
                        Console.WriteLine($"{i}) {representation}");
                        i++;
                    }

                    break;
                }
            }

            Console.ReadKey();
        }
    }
}
