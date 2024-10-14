using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace выделение_метода
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double y = F(2, 3) + F(5, 7) + F(4, 6);
            Console.WriteLine("x = " + Math.Round(y, 3));

            Console.ReadKey();
        }
        static double F(double a, double b)
        {
            return (Math.Exp(a) - Math.Exp(-a)) / (Math.Exp(b) + Math.Exp(-b));
        }
    }
}
