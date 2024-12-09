using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_массивы
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите небольшой текст (в одну строку): ");
            string input = Console.ReadLine();

            string[] words = input.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(word => new string(word.Where(char.IsLetterOrDigit).ToArray()))
                                   .ToArray();

            PrintWords(words);

            CapitalizeFirstLetter(words);
            Console.WriteLine("\nСлова с заглавной буквы:");
            PrintWords(words);

            double averageLength = CalculateAverageLength(words);
            Console.WriteLine($"\nСредняя длина слов составляет: {averageLength}");

            string[] reversedWords = ReversedWords(words);
            Console.WriteLine("\nСлова с противоположным порядком символов: ");
            PrintWords(reversedWords);

            Console.ReadKey();
        }

        static void PrintWords(string[] words)
        {
            foreach (var word in words)
                Console.WriteLine(word);
        }

        static void CapitalizeFirstLetter(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                {
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
                }
            }
        }

        static double CalculateAverageLength(string[] words)
        {
            if (words.Length == 0)
                return 0;

            int totalLength = 0;

            foreach (var word in words)
                totalLength += words.Length;

            return (double)totalLength / words.Length;
        }

        static string[] ReversedWords(string[] words)
        {
            return words.Select(word => new string(word.Reverse().ToArray()).ToLower()).ToArray();
        }
    }
}