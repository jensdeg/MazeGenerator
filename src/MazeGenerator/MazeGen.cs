namespace MazeGenerator
{
    public static class MazeGen
    {
        public static Maze Generate(uint size, Algorithm algorithm, EventHandler<Point>? gridChangedEvent = null)
        {
            var emptyMaze = new Maze(size, gridChangedEvent);
            var maze = algorithm switch
            {
                Algorithm.Kruskals => Kruskals(emptyMaze),
                _ => Random(emptyMaze)
            };
            return maze;
        }

        private static Maze Kruskals(Maze maze)
        {
            var wallSegments = maze
                .GenerateWalls()
                .GetWallSegments();

            return maze;
        }

        private static Maze Random(Maze maze)
        {
            bool solved = false;

            while (!solved) // brutforcing a new maze untill its solvable
            {
                var wallSegments = maze
                    .GenerateWalls()
                    .CreateStartEnd()
                    .GetWallSegments();

                var randomIterationCount = new Random()
                    .Next(wallSegments.Count / 2, wallSegments.Count);

                for (var i = 0; i < randomIterationCount; i++)
                {
                    var point = maze.GetRandomPoint(wallSegments, -1);
                    maze.SetPoint(point, 0);
                }

                if (maze.TrySolveMaze()) solved = true;
                else maze.ResetGrid();
            }

            // resetting solving path
            for (int x = 0; x < maze.Size; x++)
            {
                for (int y = 0; y < maze.Size; y++)
                {
                    if (maze.Grid[x, y] == 2) maze.SetPoint(new Point(x,y), 0);
                }
            }

            return maze;
        }
    }
    public enum Algorithm
    {
        Random = default,
        Kruskals
    }
}