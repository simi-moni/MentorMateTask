using System;

namespace mentorMateTask
{
    class BuildGrid
    {
        //tried to implement some features to become more OOP
        public int WidthX { get; set; }
        public int HeightY { get; set; }
        public Cell[,] Cells { get; set; }

        public BuildGrid(int width, int height)
        {
            this.WidthX = width;
            this.HeightY = height;
            this.Cells = new Cell[width, height];
        }

        public BuildGrid(BuildGrid grid)
        {
            this.Cells = grid.Cells.Clone() as Cell[,];
            this.HeightY = grid.HeightY;
            this.WidthX = grid.WidthX;
        }

        //function to find the sum of all neighbors for given cell
        public static int CountSumOfNeighbors(int[,] grid, int x, int y)
        {
            int rowLimit = grid.GetLength(0) - 1;
            int columnLimit = grid.GetLength(1) - 1;
            int sum = 0;
            //looping through all neighbors
            for (int i = Math.Max(0, x - 1); i <= Math.Min(x + 1, rowLimit); i++)
            {
                for (int j = Math.Max(0, y - 1); j <= Math.Min(y + 1, columnLimit); j++)
                {
                    sum += grid[i, j];
                }
            }
            //minus the current cell
            return sum - grid[x, y];
        }

        //function that is rebuilding the grid according to the rules
        public static int[,] Rebuild(int[,] oldvalues, int height, int width)
        {
            //making new grid
            int[,] nextGen = new int[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    //current state of the cell
                    int state = oldvalues[i, j];
                    //find the sum of the neighbors of the current cell
                    int neighborsSum = CountSumOfNeighbors(oldvalues, i, j);
                    //applying the rules
                    if (state == 0)
                        if (neighborsSum == 3 || neighborsSum == 6)
                            nextGen[i, j] = 1;
                        else nextGen[i, j] = 0;
                    else if (state == 1)
                        if (neighborsSum == 2 || neighborsSum == 3 || neighborsSum == 6)
                            nextGen[i, j] = 1;
                        else nextGen[i, j] = 0;
                }
            }
            return nextGen;
        }

        public BuildGrid Copy()
        {
            return new BuildGrid(this);
        }
    }
}


