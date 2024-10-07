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
            PrintSinusCosinus(angleInDegrees);


            Console.ReadKey();
        }

        private static void PrintSinusCosinus(double angleInDegrees)
        {
            double angleInRadians = angleInDegrees * Math.PI / 180;
            double sin = Math.Sin(angleInRadians);
            double cos = Math.Cos(angleInRadians);

            Console.WriteLine("sin(15°) = " + Math.Round(sin, 3));
            Console.WriteLine("cos(15°) = " + Math.Round(cos, 3));
        }
    }
}
