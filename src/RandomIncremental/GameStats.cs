using BreakInfinity;

namespace RandomIncremental;

public class GameStats
{
    public uint TickRate { get; set; } = 1000;

    public BigDouble Value { get; set; } = 0;

    public BigDouble Max { get; set; } = 10;
    public BigDouble Min { get; set; } = 0;
}
