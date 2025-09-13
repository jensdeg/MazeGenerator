namespace MazeGenerator
{
    public class Maze(uint size)
    {
        public uint Size { get; private set; } = size;

        public byte[,] Grid { get; private set; } = new byte[size, size];

        public override string ToString()
        {
            var gridString = string.Empty;
            for(int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    if(Grid[x, y] == 0)
                    {
                        gridString += "  ";
                    }
                    if (Grid[x, y] == 1)
                    {
                        gridString += "[]";
                    }
                }
                gridString += Environment.NewLine;
            }
            return gridString;
        }
    }
}
