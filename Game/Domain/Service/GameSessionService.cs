namespace DominionProtocol.Domain.Service;

using System;
using DominionProtocol.Domain.Model;
using DominionProtocol.Domain.Repository;

public class GameSessionService : IGameSessionService
{
    private readonly IGameSessionRepository _repository;

    public GameSessionService(IGameSessionRepository repository)
    {
        _repository = repository;
    }

    public Game GetCurrent()
    {
        return _repository.Load() ?? throw new InvalidOperationException("No game session found.");
    }

    public void SetCurrent(Game game)
    {
        _repository.Save(game);
    }
}
