using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = new List<double>();
            double input;

            Console.WriteLine("Введите последовательность неотрицательных действительных чисел (введите отрицательное число для завершения ввода):");

            while (true)
            {
                string userInput = Console.ReadLine();

                if (double.TryParse(userInput, out input))
                {
                    if (input < 0)
                    {
                        break;
                    }

                    numbers.Add(input);
                }
                else
                {
                    Console.WriteLine("Пожалуйста, введите действительное число.");
                }
            }

            numbers.Add(0);

            int maxCount = 0;
            int currentCount = 0;

            foreach (double number in numbers)
            {
                if (number > 0)
                {
                    currentCount++;
                }
                else
                {
                    if (currentCount > maxCount)
                    {
                        maxCount = currentCount;
                    }
                    currentCount = 0;
                }
            }

            Console.Write($"\nНаибольшее количество идущих подряд положительных чисел: {maxCount}");
            Console.ReadKey();
        }
    }
}
