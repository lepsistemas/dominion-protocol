using System.Collections.Generic;
using System.Threading.Tasks;
using DominionProtocol.Domain.Model;

namespace DominionProtocol.Domain.UseCase;

public interface IChooseNationUseCase
{
    Task<List<Nation>> GetAvailableNations();
    void SelectNation(Nation nation);
}
