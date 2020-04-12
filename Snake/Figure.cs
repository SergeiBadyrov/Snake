using System.Collections.Generic;

namespace Snake
{
    internal class Figure
    {
        // Набор точек - это любая фигура в приложении.
        protected List<Point> pList;

        // Функция, позволяющая отрисовать набор точек (фигуру).
        public void Draw()
        {
            foreach (Point p in pList)
            {
                p.Draw();
            }
        }

        public void Clear()
        {
            foreach (Point p in pList)
            {
                p.Clear();
            }
        }

        internal bool IsHit(Figure figure)
        {
            foreach (var p in pList)
            {
                if (figure.IsHit(p))
                    return true;
            }

            return false;
        }

        private bool IsHit(Point point)
        {
            foreach (var p in pList)
            {
                if (p.IsHit(point))
                    return true;
            }

            return false;
        }
    }
}
