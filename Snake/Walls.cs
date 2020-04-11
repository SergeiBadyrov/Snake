using System.Collections.Generic;

namespace Snake
{
    // Контейнер для стен.
    internal class Walls
    {
        private readonly List<Figure> _wallList;

        public Walls(int mapWidth, int mapHeight)
        {
            _wallList = new List<Figure>();

            // Создание стен (2 горизонтальных и 2 вертикальных линии).
            HorizontalLine upLine = new HorizontalLine(0, mapWidth - 2, 0, '+');
            HorizontalLine downLine = new HorizontalLine(0, mapWidth - 2, mapHeight - 1, '+');
            VerticalLine leftLine = new VerticalLine(0, mapHeight - 1, 0, '+');
            VerticalLine rightLine = new VerticalLine(0, mapHeight - 1, mapWidth - 2, '+');

            // Добавление готовых стен в список.
            _wallList.Add(upLine);
            _wallList.Add(downLine);
            _wallList.Add(leftLine);
            _wallList.Add(rightLine);
        }

        // Проверка на столкновение со стеной.
        internal bool IsHit(Figure figure)
        {
            foreach (var wall in _wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }

        // Отрисовка стен.
        public void Draw()
        {
            foreach (var wall in _wallList)
            {
                wall.Draw();
            }
        }
    }
}
