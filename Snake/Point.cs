using System;

namespace Snake
{
    internal class Point
    {
        // Координаты точки и символ, которым она обозначается.
        public int x;
        public int y;
        public char sym;

        public Point(int x, int y, char sym)
        {
            this.x = x;
            this.y = y;
            this.sym = sym;
        }

        public Point(Point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }

        // Сдвиг точки по определенному направлению (enum Direction).
        public void Move(int offset, Direction direction)
        {
            switch (direction)
            {
                case Direction.RIGHT:
                    {
                        x += offset;
                        break;
                    }
                case Direction.LEFT:
                    {
                        x -= offset;
                        break;
                    }
                case Direction.UP:
                    {
                        y -= offset;
                        break;
                    }
                case Direction.DOWN:
                    {
                        y += offset;
                        break;
                    }
            }
        }

        // Проверка на столкновение одной точки с другой.
        public bool IsHit(Point p)
        {
            return p.x == this.x && p.y == this.y;
        }

        // Отрисовка точки по координатам. Составляющая метода Draw для фигуры.
        public void Draw()
        {
            Console.SetCursorPosition( x, y );
            Console.Write( sym );			
        }

        // Стирание точки.
        public void Clear()
        {
            sym = ' ';
            Draw();
        }
    }
}
