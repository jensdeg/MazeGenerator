using MazeGenerator;

Maze maze = MazeGen.Generate(25, Algorithm.Kruskals);

Console.WriteLine(maze);
