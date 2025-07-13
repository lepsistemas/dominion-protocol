using DominionProtocol.Domain.Model;

namespace DominionProtocol.Domain.UseCase;

public interface ISetPeriodUseCase
{
    void Execute(HistoricalPeriod period);
}
