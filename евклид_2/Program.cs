using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Евклид;

namespace евклид_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var p = new Point() { X = 1, Y = 3 }; 

            var q = new Point();
            q.X = -1;
            q.Y = 3;

            PrintPoint(p);
            PrintPoint(q);

            Console.WriteLine(new Point(5,6);
            
           Console.ReadKey();
        }
        static void PrintPoint (Point point)
        {
            Console.WriteLine($"Точка {point.X}; {point.Y}");
        }
    }
}
