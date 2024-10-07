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
            PrintSinusCosinus(15);
            PrintSinusCosinus(37);
            PrintSinusCosinus(113);

            Console.WriteLine();
            Console.WriteLine("Введите значение угла в градусах");
            angleInDegrees = double.Parse(Console.ReadLine());
            PrintSinusCosinus(angleInDegrees);

            Console.ReadKey();
        }

        private static void PrintSinusCosinus(double angleInDegrees)
        {
            double angleInRadians = angleInDegrees * Math.PI / 180;
            double sin = Math.Sin(angleInRadians);
            double cos = Math.Cos(angleInRadians);

            Console.WriteLine("sin(" + angleInDegrees + "°) = " + Math.Round(sin, 3));
            Console.WriteLine("cos(" + angleInDegrees + "°) = " + Math.Round(cos, 3));
        }
    }
}
