using System.Collections.Generic;
using System.Threading.Tasks;
using DominionProtocol.Domain.Model;

namespace DominionProtocol.Domain.Repository;

public interface ICardRepository
{
    Task<List<Card>> GetAll();
    Task<List<Card>> GetAvailableForPeriod(HistoricalPeriod period);
}
