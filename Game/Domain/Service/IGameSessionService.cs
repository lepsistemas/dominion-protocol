namespace DominionProtocol.Domain.Service;

using DominionProtocol.Domain.Model;

public interface IGameSessionService
{
    Game GetCurrent();
    void SetCurrent(Game game);
}
