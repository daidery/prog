using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21._10_задание_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string whiteFigurePos, blackFigurePos, targetPos;

            Console.Write("Введите позицию белого слона (буква + цифра, без пробелов): ");
            whiteFigurePos = Console.ReadLine();

            Console.Write("Введите позицию черной ладьи (буква + цифра, без пробелов): ");
            blackFigurePos = Console.ReadLine();

            if (!IsCorrectPosition(whiteFigurePos) || !IsCorrectPosition(blackFigurePos))
            {
                Console.WriteLine("Некорректные позиции фигур. Попробуйте снова.");
                Console.ReadKey();
                return;
            }

            if (whiteFigurePos == blackFigurePos)
            {
                Console.WriteLine("Позиции фигур не должны совпадать. Попробуйте снова.");
                Console.ReadKey();
                return;
            }

            DecodePosition(whiteFigurePos, out int WhiteFigX, out int WhiteFigY);
            DecodePosition(blackFigurePos, out int BlackFigX, out int BlackFigY);

            if (IsWhiteFigUnderAttack(WhiteFigX, WhiteFigY, BlackFigX, BlackFigY))
            {
                Console.WriteLine("Белый слон находится под боем черной ладьи.");
                Console.ReadKey();
                return;
            }

            if (IsBlackFigUnderAttack(WhiteFigX, WhiteFigY, BlackFigX, BlackFigY))
            {
                Console.WriteLine("Черная ладья находится под боем белого слона.");
                Console.ReadKey();
                return;
            }

            Console.Write("Введите позицию предполагаемого хода белого слона: ");
            targetPos = Console.ReadLine();

            if (!IsCorrectPosition(targetPos))
            {
                Console.WriteLine("Некорректная позиция хода. Попробуйте снова.");
                Console.ReadKey();
                return;
            }

            if (CanWhiteFigureMove(WhiteFigX, WhiteFigY, targetPos))
                Console.WriteLine("Белый слон может сделать ход на " + targetPos);
            else
                Console.WriteLine("Белый слон не может сделать ход на " + targetPos);

            Console.ReadKey();
        }

        static bool IsCorrectPosition(string position)
        {
            return position.Length == 2 && position[0] >= 'a' && position[0] <= 'h' && position[1] >= '1' && position[1] <= '8';
        }

        static void DecodePosition(string position, out int x, out int y)
        {
            x = position[0] - 'a';
            y = position[1] - '1';
        }

        static bool IsWhiteFigUnderAttack(int WhiteFigX, int WhiteFigY, int BlackFigX, int BlackFigY)
        {
            return WhiteFigX == BlackFigX || WhiteFigY == BlackFigY;
        }

        static bool IsBlackFigUnderAttack(int WhiteFigX, int WhiteFigY, int BlackFigX, int BlackFigY)
        {
            return (WhiteFigX == WhiteFigY && BlackFigY == BlackFigX) || (Math.Abs(WhiteFigX - BlackFigX) == Math.Abs(WhiteFigY - BlackFigY));
        }

        static bool CanWhiteFigureMove(int WhiteFigX, int WhiteFigY, string targetPosition)
        {
            DecodePosition(targetPosition, out int targetX, out int targetY);

            return Math.Abs(WhiteFigX - targetX) == Math.Abs(WhiteFigY - targetY);
        }
    }
}
