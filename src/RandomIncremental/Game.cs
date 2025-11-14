namespace RandomIncremental;

public class Game
{
    public uint TickRate { get; set; } = 100;
    public readonly GameStats GameStats = new();

    private readonly List<TickableBase> _tickables;
    private Timer? _timer;

    public Game()
    {
        _tickables = typeof(Game).Assembly
            .GetTypes()
            .Where(t =>
                typeof(TickableBase).IsAssignableFrom(t) &&
                !t.IsAbstract &&
                t.IsClass)
            .Select(t => (TickableBase)Activator.CreateInstance(t)!)
            .OrderBy(t => t.Priority)
            .ToList() ?? [];

        foreach (var tickable in _tickables)
        {
            tickable.SetGameStats(GameStats);
            tickable.OnInitialized();
        }
    }

    public void Start() => _timer = new Timer(_ => Tick(), null, 0, TickRate);

    public void Stop() => _timer?.Dispose();

    private void Tick() => _tickables.ForEach(t => t.OnTick());
}

public abstract class TickableBase
{
    protected GameStats GameStats { get; private set; } = null!;
    public virtual uint Priority => 0;
    public virtual void OnInitialized() { }
    public abstract void OnTick();
    public void SetGameStats(GameStats stats) => GameStats = stats;
}