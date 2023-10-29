using System;
using System.Collections.Generic;
using System.Text;

namespace snake
{
    class Positions
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public Positions(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}
