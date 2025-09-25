using MazeGenerator;

var maze = MazeGen.Generate(25, Algorithm.Random, OnGridChanged);

Console.WriteLine("Done");
Console.ReadLine();

static void OnGridChanged(object? sender, Point point)
{
    Console.Clear();
    Console.WriteLine(sender);
    //Thread.Sleep(1);
}