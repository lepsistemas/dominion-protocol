using System.Threading.Tasks;

namespace DominionProtocol.Domain.UseCase;

public interface IPlayFullTurnUseCase
{
    Task Execute(PlayFullTurnInput input);
}