using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace задание_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите сторону ромба");
            double side = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите угол ромба");
            double angle = Math.PI * double.Parse(Console.ReadLine()) / 180;

            double sin = Math.Sin(angle);
            double s = side * side * sin;
            double p = 4 * side;

            Console.WriteLine("Площадь ромба: " + Math.Round(s, 3));
            Console.WriteLine("Периметр ромба: " + Math.Round(p, 3));

            Console.ReadKey();
        }
    }
}
