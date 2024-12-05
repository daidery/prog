using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Значение h, км\tРасстояние до линии горизонта, км");

            for (int h = 1; h <= 10; h++)
            {
                Console.WriteLine($"{h}\t\t{Math.Round(Math.Sqrt(h * (2 * 6350 + h)), 2)}");
            }

            Console.ReadKey();
        }
    }
}
