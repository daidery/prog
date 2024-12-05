using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите натуральное число с различными цифрами: ");
            string input = Console.ReadLine();

            if (!IsValidInput(input))
            {
                Console.WriteLine("Ошибка ввода, попробуйте заново");
                Console.ReadKey();
                return;
            }

            int minDigit = 10;
            int minPosition = -1;

            for (int i = 0; i < input.Length; i++)
            {
                int currentDigit = input[i] - '0';

                if (currentDigit < minDigit)
                {
                    minDigit = currentDigit;
                    minPosition = i + 1;
                }
            }

            Console.WriteLine($"Порядковый номер минимальной цифры: {minPosition}");
            Console.ReadKey();
        }

        static bool IsValidInput(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            bool[] digitSeen = new bool[10];

            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                    return false;

                int digit = c - '0';

                if (digitSeen[digit])
                    return false;

                digitSeen[digit] = true;
            }

            return true;  
        }
    }
}
