namespace DominionProtocol.Domain.Model;

public class GameSettings
{
    public HistoricalPeriod? Period { get; }
    public Nation? Nation { get; }

    public GameSettings()
    {
    }

    public GameSettings(HistoricalPeriod? period, Nation? nation)
    {
        Period = period;
        Nation = nation;
    }

    public GameSettings WithPeriod(HistoricalPeriod newPeriod) =>
        new GameSettings(newPeriod, Nation);

    public GameSettings WithNation(Nation newNation) =>
        new GameSettings(Period, newNation);
}
