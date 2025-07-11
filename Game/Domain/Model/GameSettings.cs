namespace DominionProtocol.Domain.Model;

public static class GameSettings
{
    public static HistoricalPeriod SelectedPeriod { get; private set; }
    public static Nation SelectedNation { get; private set; } = default!;

    public static void SetPeriod(HistoricalPeriod period) => SelectedPeriod = period;
    public static void SetNation(Nation nation) => SelectedNation = nation;
}
