using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Целочисленная_арифметика
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите четырехзначное число");
            var number = int.Parse(Console.ReadLine());

            var units = number % 1000 % 100 % 10;
            var tenths = number / 10 % 10;
            var hundreds = number / 100 % 10;
            var thousands = number / 1000;
            var result = thousands * 1000 + tenths * 100 + hundreds * 10 + units;

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
