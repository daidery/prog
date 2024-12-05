using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите площадь прямоугольника (натуральное число): ");
            int s;

            while (!int.TryParse(Console.ReadLine(), out s) || s <= 0)
            {
                Console.WriteLine("Пожалуйста, введите натуральное число.");
            }

            Console.WriteLine($"\nПрямоугольники с площадью {s}:\n");
            FindRectangles(s);
            Console.ReadKey();
        }

        static void FindRectangles(int s)
        {
            for (int length = 1; length <= Math.Sqrt(s); length++)
            {
                if (s % length == 0)
                {
                    int width = s / length;
                    Console.WriteLine($"Сторона_1 = {length}, Сторона_2 = {width}");
                }
            }
        }
    }
}
