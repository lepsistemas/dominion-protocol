namespace DominionProtocol.Domain.Service;

using DominionProtocol.Domain.Model;
using System.Threading.Tasks;

public interface ITurnExecutorService
{
    Task Execute(Game game, Player player, IPlayerInput input);
}
