using System;
using System.Collections.Generic;
using System.Threading;

namespace snake
{
    class Program
    {
        
        static void Game()
        {
           
            Snake snake = new Snake();
            snake.SnakeMain();
            ConsoleKey key = ConsoleKey.RightArrow;
            while (true)
            {
                Thread.Sleep(180);               
                if (Console.KeyAvailable)
               key = Console.ReadKey(true).Key;
                switch (key)
                {
                        case ConsoleKey.UpArrow:

                        if (!snake.IsValiid(snake.snakePos[snake.snakePos.Count - 1].Row - 1, snake.snakePos[snake.snakePos.Count - 1].Col))
                            
                            return;
                        snake.MoveSnake(snake.snakePos[snake.snakePos.Count - 1].Row - 1, snake.snakePos[snake.snakePos.Count - 1].Col);
                       break;
                        case ConsoleKey.DownArrow:
                        if (!snake.IsValiid(snake.snakePos[snake.snakePos.Count - 1].Row + 1, snake.snakePos[snake.snakePos.Count - 1].Col))
                            return;
                        snake.MoveSnake(snake.snakePos[snake.snakePos.Count - 1].Row + 1, snake.snakePos[snake.snakePos.Count - 1].Col);
                        break;
                        case ConsoleKey.RightArrow:
                        if (!snake.IsValiid(snake.snakePos[snake.snakePos.Count - 1].Row , snake.snakePos[snake.snakePos.Count - 1].Col+1))
                            return;
                        snake.MoveSnake(snake.snakePos[snake.snakePos.Count - 1].Row, snake.snakePos[snake.snakePos.Count - 1].Col + 1);
                        break;
                        case ConsoleKey.LeftArrow:
                        if (!snake.IsValiid(snake.snakePos[snake.snakePos.Count - 1].Row, snake.snakePos[snake.snakePos.Count - 1].Col-1))
                            return;
                        snake.MoveSnake(snake.snakePos[snake.snakePos.Count - 1].Row, snake.snakePos[snake.snakePos.Count - 1].Col - 1);
                        break;

                }
               
              
            }
        }
    
          
            

       static void Main(string[] args)
       {
            Console.SetCursorPosition(70, 1);
            Console.WriteLine("wellcome to our game!" + (char)3 + (char)3 + (char)3);
            Game();
            Console.SetCursorPosition(0, 30);
           

        }

        
    }
}
