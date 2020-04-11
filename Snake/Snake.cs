using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake
{
    internal class Snake : Figure
    {
        Direction _direction;

        // Змейка задается стартовым положением, длиной и направлением головы.
        public Snake(Point tail, int length, Direction direction)
        {
            _direction = direction;

            pList = new List<Point>();
            for (int i = 0; i < length; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direction);
                pList.Add(p);
            }
        }

        // Метод, который отвечает за движение змеи.
        public void Move()
        {
            Point tail = pList.First();
            pList.Remove(tail);

            Point head = GetNextPoint();
            pList.Add(head);

            tail.Clear();
            head.Draw();
        }

        // Метод, который получает точку змеи, которая будет отрисована в следующий момент времени.
        public Point GetNextPoint()
        {
            Point head = pList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, _direction);
            return nextPoint;
        }

        // Проверка на столкновение с собственным хвостом.
        public bool IsHitTail()
        {
            var head = pList.Last();
            for (int i = 0; i < pList.Count - 2; i++)
            {
                if (head.IsHit(pList[i]))
                    return true;
            }
            return false;
        }

        // Смена направления стрелками на клавиатуре
        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow && _direction != Direction.RIGHT)
                _direction = Direction.LEFT;
            else if (key == ConsoleKey.RightArrow && _direction != Direction.LEFT)
                _direction = Direction.RIGHT;
            else if (key == ConsoleKey.DownArrow && _direction != Direction.UP)
                _direction = Direction.DOWN;
            else if (key == ConsoleKey.UpArrow && _direction != Direction.DOWN)
                _direction = Direction.UP;
        }

        // Метод, который показывает, съест ли змея еду в данный момент времени.
        public bool Eat(Point food)
        {
            Point head = GetNextPoint();

            if (head.IsHit(food))
            {
                food.sym = head.sym;
                pList.Add(food);
                return true;
            }
            else
                return false;
        }
    }
}
