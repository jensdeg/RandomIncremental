namespace RandomIncremental;

public class Game
{
    public uint TickRate { get; set; } = 100;

    private readonly List<ITickable> _tickables;
    private Timer? _timer;

    public Game()
    {
        _tickables = typeof(Game).Assembly
            .GetTypes()
            .Where(t => typeof(ITickable).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
            .Select(t => (ITickable)Activator.CreateInstance(t)!)
            .OrderBy(t => t.Priority)
            .ToList() ?? [];
    }

    public void Start()
    {
        _tickables.ForEach(t => t.OnInitialized());
        _timer = new Timer(_ => Tick(), null, 0, TickRate);
    }

    public void Stop() => _timer?.Dispose();

    private void Tick() => _tickables.ForEach(t => t.OnTick());

}

public interface ITickable
{
    uint Priority { get; }
    void OnTick();
    virtual void OnInitialized() { }
}