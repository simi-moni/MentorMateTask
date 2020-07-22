using System;

namespace mentorMateTask
{
    //tried to implement some features to become more OOP
    class Cell
    {
        private int Value { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Cell(int value)
        {
            this.Value = value;
        }
        public Cell(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
