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
            var maze = new Maze(size)
                .GenerateWalls();

            return maze;
        }
    }

    public enum Algorithm
    {
        Kruskals
    }
}