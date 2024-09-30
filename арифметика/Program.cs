using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace арифметика
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double angleInDegrees = 15;
            double angleInRadians = angleInDegrees * Math.PI / 180;
            double sin = Math.Sin(angleInRadians);
            double cos = Math.Cos(angleInRadians);

            Console.WriteLine("sin(15°) = " + Math.Round(sin, 3));
            Console.WriteLine("cos(15°) = " + Math.Round(cos, 3));

            angleInDegrees = 37;
            angleInRadians = angleInDegrees * Math.PI / 180;
            sin = Math.Sin(angleInRadians);
            cos = Math.Cos(angleInRadians);

            Console.WriteLine("sin(37°) = " + Math.Round(sin, 3));
            Console.WriteLine("cos(37°) = " + Math.Round(cos, 3));

            angleInDegrees = 113;
            angleInRadians = angleInDegrees * Math.PI / 180;
            sin = Math.Sin(angleInRadians);
            cos = Math.Cos(angleInRadians);

            Console.WriteLine("sin(113°) = " + Math.Round(sin, 3));
            Console.WriteLine("cos(113°) = " + Math.Round(cos, 3));

            Console.WriteLine();
            Console.WriteLine("Введите значение угла в градусах");
            angleInDegrees =  double.Parse(Console.ReadLine());
            angleInRadians = angleInDegrees * Math.PI / 180;
            sin = Math.Sin(angleInRadians);
            cos = Math.Cos(angleInRadians);

            Console.WriteLine("sin(" + angleInDegrees + "°) = " + Math.Round(sin, 3));
            Console.WriteLine("cos(" + angleInDegrees + "°) = " + Math.Round(cos, 3));


            Console.ReadKey();
        }
    }
}
