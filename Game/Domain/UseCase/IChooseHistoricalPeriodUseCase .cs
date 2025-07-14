using DominionProtocol.Domain.Model;

namespace DominionProtocol.Domain.UseCase;

public interface IChooseHistoricalPeriodUseCase 
{
    GameSettings Execute(HistoricalPeriod period);
}
