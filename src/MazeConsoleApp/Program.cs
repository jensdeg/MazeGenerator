using MazeGenerator;

var maze = MazeGen.Generate(50, Algorithm.Random, Maze_OnGridChanged);

Console.WriteLine("Done");
Console.ReadLine();

static void Maze_OnGridChanged(object? sender, int[,] maze)
{
    Console.Clear();
    Console.WriteLine(sender);
    //Thread.Sleep(1);
}