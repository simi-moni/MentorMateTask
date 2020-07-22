using System;

namespace mentorMateTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int width, height, targetX, targetY;
            int counter = 0;
            int counterGreen = 0;
            try
            {
                int[] size = Input.GridDimensions();
                // BuildGrid initialGrid = Input.GridValues(size);
                height = size[0];
                width = size[1];
                int[,] initialGrid = new int[height, width];
                //filling the initial grid with user input
                for (int i = 0; i < height; i++)
                {
                    string line = Console.ReadLine().Trim();
                    var row = Array.ConvertAll(line.Split(' '), int.Parse);

                    for (int j = 0; j < width; j++)
                    {
                        initialGrid[i, j] = row[j];
                    }
                }

                Cell targetCell = Input.TargetCoordinates(out int generetionN);
                targetX = targetCell.X;
                targetY = targetCell.Y;
                ValidateGridCoordinates(initialGrid, targetX, targetY);
                //creating a new grid with the same values
                var nextGen = new int[height, width];
                nextGen = initialGrid;
                //rebuilding the grid N times
                do
                {
                    //checks if the current cell is "green"
                    if (nextGen[targetX, targetY] == 1)
                        ++counterGreen;
                    nextGen = BuildGrid.Rebuild(nextGen, height, width);
                    //prints the grid to the console
                    for (int i = 0; i < nextGen.GetLength(0); i++)
                    {
                        for (int j = 0; j < nextGen.GetLength(1); j++)
                        {
                            Console.Write(nextGen[i, j] + " ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    counter++;
                } while (counter <= generetionN);
                Console.WriteLine("The result is: " + counterGreen);
            }
            catch (Exception)
            {
                Console.WriteLine("Some error occured.");
            }
            Console.Read();
        }

        public static bool ValidateGridCoordinates(int[,] grid, int x, int y)
        {
            if (x < 0 || y < 0 || x > grid.GetLength(0) - 1 || y > grid.GetLength(1) - 1 || x >= y || y > 1000)
            {
                Console.WriteLine("Index is Out Of Bounds");
                return false;
            }
            return true;
        }

    }
}




