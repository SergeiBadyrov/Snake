using System;

namespace Snake
{
    internal static class GameFinish
    {
        public static void WriteGameOver(int score)
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            WriteText("Game over. Your score: " + score, xOffset + 1, yOffset++);
            yOffset++;
            WriteText("Designed by: Sergei Badyrov", xOffset, yOffset++);
            WriteText("============================", xOffset, yOffset++);
        }

        private static void WriteText(string text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
}
