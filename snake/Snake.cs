using System;
using System.Collections.Generic;
using System.Text;

namespace snake
{
    class Snake
    {
        public List<Positions> snakePos { get; set; } = new List<Positions>();
        public Positions Food  { get; set; } = new Positions(7, 30);
        public int Points { get; set; } = 0;
        public void FillBorders()
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine(" ");
                Console.SetCursorPosition(60, i);
                Console.WriteLine(" ");
            }
            for (int i = 0; i <= 60; i++)
            {
                Console.SetCursorPosition(i, 20);
                Console.WriteLine(" ");
                Console.SetCursorPosition(i, 0);
                Console.WriteLine(" ");
            }
            Console.BackgroundColor = ConsoleColor.Black;

        }
        public void CreatePositionsList()
        {
            snakePos.Add(new Positions(3, 3));
            snakePos.Add(new Positions(4, 3));
            snakePos.Add(new Positions(5, 3));
            snakePos.Add(new Positions(6, 3));
            snakePos.Add(new Positions(7, 3));

            foreach (var item in snakePos)
            {
                Console.SetCursorPosition(item.Col, item.Row);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine('@');
            }

        }
       
        public void PrintChar(Positions pos,char x)
        {
            Console.SetCursorPosition(pos.Col, pos.Row);
            switch (x)
            {
                case '@':
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case '$':
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                default:
                    break;
            }
            Console.WriteLine(x);

        }
        public bool IsValiid1(int row, int col)
        {
            foreach (var item in snakePos)
            {
                if (item.Row == row && item.Col == col)
                    return false;
            }
            return true;
        }
        public bool IsValiid(int row, int col)
        {
            if (row == 0 || col == 0 || row == 20 || col == 60 || !IsValiid1(row,col) /*snakePos.Contains(new Positions(row, col))*/)
            {
                Console.SetCursorPosition(80, 10);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("game over!!!");
                Console.ForegroundColor = ConsoleColor.Yellow;
                return false;
            }
            return true;
          
        }

        public bool IsEating(int row, int col)
        {
            Random random = new Random();
            if (Food.Row==row&&Food.Col==col)
            {
                Food.Row = random.Next(1, 20);
                Food.Col = random.Next(1, 60);
                Console.Beep();
                PrintChar(Food, '$');
                Points += 100;
               
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(80, 9);
                Console.WriteLine(Points+" points");
                
                return true;
            }
            return false;
        }
        public void MoveSnake(int row,int col)
        {
            if (!IsEating(row, col))
            {

                PrintChar(snakePos[0], ' ');
                snakePos.RemoveAt(0);
            }
            snakePos.Add(new Positions(row, col));
            PrintChar(snakePos[snakePos.Count-1], '@');
        }
        public void SnakeMain()
        {
            FillBorders();
            CreatePositionsList();

            PrintChar(Food, '$');
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(80, 9);
            Console.WriteLine(Points + " points");
        }
    }
}
