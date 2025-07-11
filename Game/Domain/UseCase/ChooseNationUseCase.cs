using System.Collections.Generic;
using System.Threading.Tasks;
using DominionProtocol.Domain.Model;
using DominionProtocol.Domain.Repository;

namespace DominionProtocol.Domain.UseCase;

public class ChooseNationUseCase : IChooseNationUseCase
{
    private readonly INationRepository _nationRepository;

    public ChooseNationUseCase(INationRepository nationRepository)
    {
        _nationRepository = nationRepository;
    }

    public async Task<List<Nation>> GetAvailableNations(HistoricalPeriod period)
    {
        return await _nationRepository.GetAvailableForPeriod(period);
    }
}
