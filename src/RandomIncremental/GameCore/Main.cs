using BreakInfinity;

namespace RandomIncremental.GameCore;

public class Main : TickableBase
{
    public override uint Priority => 0;

    private readonly Random _random = new();

    public override void OnTick()
        => GameStats.Value += _random.NextBigDouble(GameStats.Min, GameStats.Max);
}
