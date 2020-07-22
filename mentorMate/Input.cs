using System;
using System.Linq;

namespace mentorMateTask
{
    class Input
    {
        //function that gets the dimensions from the first line of the user input
        public static int[] GridDimensions()
        {
            var dimensions = Console.ReadLine().Trim().
                Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).ToArray();
            return dimensions;
        }

        //function that is not working yet for filling the grid according to the user input
        public static BuildGrid GridValues(int[] dimensions)
        {
            BuildGrid grid = new BuildGrid(dimensions[0], dimensions[1]);
            for (int i = 0; i < grid.HeightY; i++)
            {
                string line = Console.ReadLine().Trim();
                var row = Array.ConvertAll(line.Split(' '), int.Parse);
                for (int j = 0; j < grid.WidthX; j++)
                {
                    grid.Cells[i, j] = new Cell(row[j]);
                }
            }
            return grid;
        }

        //taking the coordinates and the number of generation we shall loop through from user
        public static Cell TargetCoordinates(out int n)
        {
            string coordinatesAndGenerations = Console.ReadLine().Trim();
            int[] coordinates = Array.ConvertAll(coordinatesAndGenerations.Split(','), int.Parse);
            int cellY = coordinates[0];
            int cellX = coordinates[1];
            Cell target = new Cell(cellX, cellY);
            n = coordinates[2];
            return target;
        }
    }
}
