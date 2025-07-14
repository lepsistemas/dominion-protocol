namespace DominionProtocol.Infrastructure.Repository;

using DominionProtocol.Domain.Model;
using DominionProtocol.Domain.Repository;

public class InMemoryGameSessionRepository : IGameSessionRepository
{
    private Game? _game;

    public Game? Load() => _game;

    public void Save(Game game) => _game = game;
}
