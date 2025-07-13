namespace DominionProtocol.Domain.Model;

public class GameSettings
{
    public HistoricalPeriod? SelectedPeriod { get; }
    public Nation? SelectedNation { get; }

    public GameSettings()
    {
    }

    public GameSettings(HistoricalPeriod? selectedPeriod, Nation? selectedNation)
    {
        SelectedPeriod = selectedPeriod;
        SelectedNation = selectedNation;
    }

    public GameSettings WithPeriod(HistoricalPeriod newPeriod) =>
        new GameSettings(newPeriod, SelectedNation!);

    public GameSettings WithNation(Nation newNation) =>
        new GameSettings(SelectedPeriod!, newNation);
}
