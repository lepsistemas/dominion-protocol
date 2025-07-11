using System.Threading.Tasks;
using DominionProtocol.Domain.Model;

namespace DominionProtocol.Domain.UseCase;

public interface IStartMatchUseCase
{
    Task<Game> Start(HistoricalPeriod period, Nation humanNation);
}
