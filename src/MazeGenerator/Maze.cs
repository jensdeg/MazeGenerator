namespace MazeGenerator
{
    public class Maze(uint size)
    {
        public uint Size { get; private set; } = size;

        public byte[,] Grid { get; private set; } = new byte[size, size];

        public Maze GenerateWalls()
        {   
            if(Size % 2 == 0) // can't generate walls on even sized grid
            {
                Size++;
                Grid = new byte[Size, Size];
            }
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                    {
                        Grid[x, y] = 1;
                    }
                }
            }
            return this;
        }

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
