namespace DominionProtocol.Domain.Repository;

using DominionProtocol.Domain.Model;

public interface IGameSessionRepository
{
    Game? Load();
    void Save(Game game);
}
