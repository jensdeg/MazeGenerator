namespace MazeGenerator
{
    public class Maze(uint size, EventHandler<int[,]>? gridChangedEvent = null)
    {
        public uint Size { get; private set; } = size;

        public int[,] Grid { get; private set; } = new int[size, size];

        public event EventHandler<int[,]> GridChanged = gridChangedEvent;

        public void SetPoint(int x, int y, int value = 1)
        {
            if (Grid[x, y] == value) return;
            Grid[x, y] = value;
            GridChanged?.Invoke(this, Grid);
        }

        public (int x, int y) GetRandomPoint(int pointvalue)
        {
            var random = new Random();
            var rndX = random.Next(0, (int)Size);
            var rndY = random.Next(0, (int)Size);

            if (Grid[rndX, rndY] != pointvalue) return GetRandomPoint(pointvalue);
            else return (rndX, rndY);
        }

        public int PointCount(int pointValue)
        {
            var count = 0;
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    if (Grid[x, y] == pointValue) count++;
                }
            }
            return count;
        }

        public Maze GenerateWalls()
        {   
            if(Size % 2 == 0) // can't generate walls on even sized grid
            {
                Size++;
                Grid = new int[Size, Size];
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
