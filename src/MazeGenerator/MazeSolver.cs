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
            foreach (var p in neighbours) 
            {
                var size = maze.Grid.GetLength(0) - 1;
                if(p.X < 0 || p.Y < 0 || p.X > size || p.Y > size) continue;
                if (maze.Grid[p.X, p.Y] >= 1) continue;
                maze.SetPoint(p, 2);
                if(maze.PointCount(0) > 0 && maze.Grid[maze.End.X, maze.End.Y] != 2)
                {
                    p.Neighbours.SetNeighbours(maze);
                }
            }
        }
    }
}
