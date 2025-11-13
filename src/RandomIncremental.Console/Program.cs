using RandomIncremental;

Game gameloop = new()
{
    TickRate = 1000
};

gameloop.Start();

Console.WriteLine("Game started. Press Enter to stop.");
Console.ReadLine();
gameloop.Stop();