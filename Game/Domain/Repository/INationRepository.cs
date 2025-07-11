using System.Collections.Generic;
using System.Threading.Tasks;
using DominionProtocol.Domain.Model;

namespace DominionProtocol.Domain.Repository;

public interface INationRepository
{
    Task<List<Nation>> GetAll();
    Task<List<Nation>> GetAvailableForPeriod(HistoricalPeriod period);
}
