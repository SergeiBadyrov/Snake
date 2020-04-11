using System;

namespace Snake
{
    internal class FoodCreator
    {
        // Ширина и высота игрового поля + символ еды.
        private readonly int _mapWidht;
        private readonly int _mapHeight;
        private readonly char _sym;

        // Генератор случайных чисел.
        private readonly Random rnd = new Random();

        public FoodCreator(int mapWidth, int mapHeight, char sym)
        {
            _mapWidht = mapWidth;
            _mapHeight = mapHeight;
            _sym = sym;
        }

        // Метод, создающий еду на поле.
        public Point CreateFood()
        {
            int x = rnd.Next(2, _mapWidht - 2);
            int y = rnd.Next(2, _mapHeight - 2);
            return new Point(x, y, _sym);
        }
    }
}
