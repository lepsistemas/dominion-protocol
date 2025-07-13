using System.Threading.Tasks;
using DominionProtocol.Domain.Model;

namespace DominionProtocol.Domain.UseCase;

public interface IStartMatchUseCase
{
    Task<StartMatchResult> Start();
}
