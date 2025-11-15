using RandomIncremental;

var game = new Game();

game.Start();

Console.WriteLine("Game started. Press Enter to stop.");
Console.ReadLine();
game.Stop();