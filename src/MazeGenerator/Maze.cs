namespace MazeGenerator
{
    public class Maze(uint size, EventHandler<int[,]>? gridChangedEvent = null)
    {
        public uint Size { get; private set; } = size;

        public int[,] Grid { get; private set; } = new int[size, size];

        public event EventHandler<int[,]> GridChanged = gridChangedEvent;

        public Maze GenerateWalls()
        {
            if (Size % 2 == 0) // can't generate walls on even sized grid
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

        public Maze CreateStartEnd()
        {
            Grid[(int)Size - 2, 0] = 0;
            Grid[1, (int)Size - 1] = 0;
            return this;
        }

        public void SetPoint(Point point, int value = 1)
        {
            if (Grid[point.X, point.Y] == value) return;
            Grid[point.X, point.Y] = value;
            GridChanged?.Invoke(this, Grid);
        }

        public Point GetRandomPoint(int pointValue)
        {
            var random = new Random();
            var rndX = random.Next((int)Size);
            var rndY = random.Next((int)Size);

            if (Grid[rndX, rndY] != pointValue && pointValue > 0) return GetRandomPoint(pointValue);
            else return new Point(rndX, rndY);
        }

        public Point GetRandomPoint(List<Point> points, int pointValue)
        {
            var rndNumber = new Random().Next(points.Count);
            var point = points[rndNumber];

            if (Grid[point.X, point.Y] != pointValue && pointValue > 0) return GetRandomPoint(points, pointValue);
            else return new Point(point.X, point.Y);
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

        public List<Point> GetWallSegments()
        {
            var size = Grid.GetLength(0);
            List<Point> points = [];
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    if (x == 0 || y == 0 ||
                        x == size - 1 || y == size - 1)
                        continue; // skip outer walls

                    if (x % 2 == 0 && y % 2 != 0) points.Add(new(x, y));
                    if (x % 2 != 0 && y % 2 == 0) points.Add(new(x, y));
                }
            }
            return points;
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

    public readonly record struct Point(int X, int Y);
}
