using DominionProtocol.Domain.Model;
using DominionProtocol.Domain.Repository;

namespace DominionProtocol.Domain.UseCase;

public class ChooseHistoricalPeriodUseCase : IChooseHistoricalPeriodUseCase 
{
    private readonly IGameSettingsRepository _repository;

    public ChooseHistoricalPeriodUseCase(IGameSettingsRepository repository)
    {
        _repository = repository;
    }

    public GameSettings Execute(HistoricalPeriod period)
    {
        var current = _repository.Load();
        if (current == null)
        {
            current = new GameSettings();
        }
        var updated = current.WithPeriod(period);
        _repository.Save(updated);
        return updated;
    }
}
