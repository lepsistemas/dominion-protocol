using DominionProtocol.Domain.Model;
using DominionProtocol.Domain.Repository;

namespace DominionProtocol.Domain.UseCase;

public class SetPeriodUseCase : ISetPeriodUseCase
{
    private readonly IGameSettingsRepository _repository;

    public SetPeriodUseCase(IGameSettingsRepository repository)
    {
        _repository = repository;
    }

    public void Execute(HistoricalPeriod period)
    {
        var current = _repository.Load();
        if (current == null)
        {
            current = new GameSettings();
        }
        var updated = current.WithPeriod(period);
        _repository.Save(updated);
    }
}
