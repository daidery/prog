using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace условные_операторы
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите значение x");
            var x = double.Parse(Console.ReadLine());

            Console.WriteLine($"f({x}) = {MyFunction(x)}");

            Console.ReadKey();
        }

        static double MyFunction(double x)
        {
            if (x < -1)
                return 1 - x * x;
            else if (x > 1)
                return x - 1;
            else return 0;
        }
    }
}
