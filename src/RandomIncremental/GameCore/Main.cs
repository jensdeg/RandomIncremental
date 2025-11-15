using BreakInfinity;

namespace RandomIncremental.GameCore;

public class Main : TickableBase
{
    private readonly Random _random = new();

    public override void OnTick()
        => GameStats.Value += _random.NextBigDouble(GameStats.Min, GameStats.Max);
}
