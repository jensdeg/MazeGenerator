namespace MazeGenerator
{
    public static class MazeSolver
    {
        public static bool TrySolveMaze(this Maze maze)
        {
            var start = Maze.Start;
            maze.SetPoint(start, 2);
            start.Neighbours.SetNeighbours(maze);

            return maze.Grid[maze.End.X, maze.End.Y] == 2;
        }

        private static void SetNeighbours(
            this IReadOnlyCollection<Point> neighbours, Maze maze)
        {
            var size = maze.Grid.GetLength(0) - 1;

            foreach (var p in neighbours) 
            {
                if (maze.Grid[maze.End.X, maze.End.Y] == 2) return;

                if(p.X < 0 || p.Y < 0 || p.X > size || p.Y > size ||
                    maze.Grid[p.X, p.Y] >= 1) continue;

                maze.SetPoint(p, 2);

                if(maze.PointCount(0) > 0)
                {
                    p.Neighbours.SetNeighbours(maze);
                }
            }
        }
    }
}
