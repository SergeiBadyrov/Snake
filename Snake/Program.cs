using System;
using System.Threading;

namespace Snake
{
    internal class Program
    {
        private static int score = 0;

        public static void Main()
        {
            #region Start game conditions

            // Создание игрового поля.
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);
            Console.CursorVisible = false;

            // Отрисовка стен.
            Walls walls = new Walls(80, 25);
            walls.Draw();

            // Отрисовка змеи.
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            // Создание первого кусочка еды.
            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            #endregion

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                    score++;
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(100);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }

            GameFinish.WriteGameOver(score);

            Console.ReadKey();
        }
    }
}
