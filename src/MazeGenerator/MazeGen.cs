namespace MazeGenerator
{
    public static class MazeGen
    {
        public static Maze Generate(uint size, Algorithm algorithm)
        {
            var maze = algorithm switch
            {
                Algorithm.Kruskals => Kruskals(size),
                _ => new Maze(size)
            };

            return maze;
        }

        private static Maze Kruskals(uint size)
        {
            Maze maze = new(size);

            // Generate walls
            for (int x = 0; x < size; x++) 
            {
                if(x %  2 == 0)
                {
                    for (int y = 0; y < size; y++)
                    {
                        maze.Grid[x, y] = 1;
                    }
                }
            }
            for (int y = 0; y < size; y++)
            {
                if (y % 2 == 0)
                {
                    for (int x = 0; x < size; x++)
                    {
                        maze.Grid[x, y] = 1;
                    }
                }
            }

            return maze;
        }
    }

    public enum Algorithm
    {
        Kruskals
    }
}
