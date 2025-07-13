using System;
using DominionProtocol.Domain.Model;
using DominionProtocol.Domain.Repository;

namespace DominionProtocol.Infra.Repository;

public class InMemoryGameSettingsRepository : IGameSettingsRepository
{
    private GameSettings _settings = default!;

    public GameSettings? Load()
    {
        return _settings;
    }

    public void Save(GameSettings settings)
    {
        _settings = settings;
    }
}
