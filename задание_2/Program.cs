using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите значение n: ");
            int n;

            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("\nНужно ввести натуральное число: ");
            }

            double sumOfSquares = 0;

            for (int i = 1; i <= n; i++)
            {
                Console.Write($"\nВведите значение k{i}: ");
                int k;

                while (!int.TryParse(Console.ReadLine(), out k) || k <= 0)
                {
                    Console.Write("\nНужно ввести натуральное число: ");
                }

                sumOfSquares += k * k;
            }

            double result = Math.Sqrt(sumOfSquares);

            Console.WriteLine($"\nКорень из суммы квадратов введенных чисел: {result}");

            Console.ReadKey();
        }
    }
}
