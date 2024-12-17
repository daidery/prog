using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace многомерные_массивы
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int m, n;
            do
            {
                Console.Write("Введите натуральное число от 5 до 20: ");
                m = Convert.ToInt32(Console.ReadLine());
            } while (m < 5 || m > 20);

            do
            {
                Console.Write("Введите еще одно натуральное число от 5 до 20: ");
                n = Convert.ToInt32(Console.ReadLine());
            } while (n < 5 || n > 20);

            int[,] array = new int[m, n];
            FillArray(array);
            PrintArray(array);

            Console.Write("Введите число: ");
            int divisor = Convert.ToInt32(Console.ReadLine());
            FindDivisibleElement(array, divisor);

            CalculateProductOfEvenElements(array);

            Console.ReadKey();
        }

        static void FillArray(int[,] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(0, 100);
                }
            }
        }

        static void PrintArray(int[,] array)
        {
            Console.WriteLine("Сгенерированный массив:");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void FindDivisibleElement(int[,] array, int divisor)
        {
            bool found = false;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] % divisor == 0)
                    {
                        Console.WriteLine($"Элемент {array[i, j]} с индексом [{i + 1}, {j + 1}] делится на {divisor}");
                        found = true;
                        return;
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine($"Нет элементов, делящихся на {divisor}.");
            }
        }

        static void CalculateProductOfEvenElements(int[,] array)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                int product = 1;
                bool hasEven = false;

                for (int i = 0; i < array.GetLength(0); i++)
                {
                    if (array[i, j] % 2 == 0)
                    {
                        product *= array[i, j];
                        hasEven = true;
                    }
                }

                if (hasEven)
                {
                    Console.WriteLine($"Произведение четных элементов в столбце {j + 1}: {product}");
                }
                else
                {
                    Console.WriteLine($"В столбце {j + 1} нет четных элементов.");
                }
            }
        }
    }
}
