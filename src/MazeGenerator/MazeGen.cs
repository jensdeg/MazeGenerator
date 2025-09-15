namespace MazeGenerator
{
    public static class MazeGen
    {
        public static Maze Generate(uint size, Algorithm algorithm, EventHandler<int[,]>? gridChangedEvent = null)
        {
            var maze = algorithm switch
            {
                Algorithm.Kruskals => Kruskals(size, gridChangedEvent),
                _ => new Maze(size)
            };

            return maze;
        }

        private static Maze Kruskals(uint size, EventHandler<int[,]>? gridChangedEvent = null)
        {
            var maze = new Maze(size, gridChangedEvent)
                .GenerateWalls();

            // temp testing
            while(maze.PointCount(0) != maze.Grid.Length)
            {
                var (x, y) = maze.GetRandomPoint(1);
                maze.SetPoint(x,y, 0);
            }

            return maze;
        }
    }

    public enum Algorithm
    {
        Kruskals
    }
}