using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ночь, улица, фонарь, аптека");


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Ночь, улица, фонарь, аптека,\nБессмысленный и тусклый свет.\nЖиви еще хоть четверть века -\nВсе будет так. Исхода нет.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = originalColor;
            
            Console.ReadKey();
        }
    }
}
