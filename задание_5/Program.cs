using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите срок депозита (в месяцах): ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Введите сумму вклада (в рублях): ");
            double m = double.Parse(Console.ReadLine());

            Console.Write("Введите процентную ставку (% годовых): ");
            double x = double.Parse(Console.ReadLine());

            double monthlyInterestRate = x / 100 / 12;

            Console.WriteLine("\nМесяц\tСумма на депозите\n");

            for (int month = 1; month <= n; month++)
            {
                m += m * monthlyInterestRate;
                Console.WriteLine($"{month}\t{m:F2}");
            }
            Console.ReadKey();
        }
    }
}
