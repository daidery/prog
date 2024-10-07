using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace методы_07._10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите значение X");
            var x = double.Parse(Console.ReadLine());

            var y = MyFunction(x);
            Console.WriteLine("f(x) = " + y);

            Console.ReadKey();
        }

        static double MyFunction(double x)
        {
            //throw new NotImplementedException();
            return Math.Sin((3.2 + Math.Sqrt(x + 1)) / Math.Abs(5 * x));
        }
    }
}
