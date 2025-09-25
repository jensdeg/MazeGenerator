namespace MazeGenerator
{
    public class Maze(uint size, EventHandler<Point>? gridChangedEvent = null)
    {
        public uint Size { get; private set; } = size;

        public int[,] Grid { get; private set; } = new int[size, size];

        public static Point Start => new(1, 0);

        public Point End => new((int)Size - 2, (int)Size - 1);

        public event EventHandler<Point>? GridChanged = gridChangedEvent;

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
            SetPoint(Start, 0);
            SetPoint(End, 0);
            return this;
        }

        public void SetPoint(Point point, int value = 1)
        {
            if (Grid[point.X, point.Y] == value) return;
            Grid[point.X, point.Y] = value;
            GridChanged?.Invoke(this, point);
        }

        public Point GetRandomPoint(int pointValue)
        {
            var random = new Random();
            var rndX = random.Next((int)Size);
            var rndY = random.Next((int)Size);

            if (Grid[rndX, rndY] != pointValue && pointValue >= 0) return GetRandomPoint(pointValue);
            else return new Point(rndX, rndY);
        }

        public Point GetRandomPoint(List<Point> points, int pointValue)
        {
            var rndNumber = new Random().Next(points.Count);
            var point = points[rndNumber];

            if (Grid[point.X, point.Y] != pointValue && pointValue >= 0) return GetRandomPoint(points, pointValue);
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

        public void ResetGrid()
        {
            Grid = Grid = new int[Size, Size];
        }

        public List<Point> GetWallSegments()
        {
            List<Point> points = [];
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    if (x == 0 || y == 0 ||
                        x == Size - 1 || y == Size - 1)
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
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    var gridValue = Grid[x, y] switch
                    {
                        0 => "  ",
                        1 => "██",
                        2 => "░░",
                        _ => "  ",
                    };
                    gridString += gridValue;
                }
                gridString += Environment.NewLine;
            }
            return gridString;
        }
    }

    public readonly record struct Point(int X, int Y)
    {
        public IReadOnlyCollection<Point> Neighbours => [
            new(X + 1, Y),
            new(X - 1, Y),
            new(X, Y + 1),
            new(X, Y - 1)
        ];
    }
}
