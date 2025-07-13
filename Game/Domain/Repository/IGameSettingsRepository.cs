using DominionProtocol.Domain.Model;

namespace DominionProtocol.Domain.Repository;

public interface IGameSettingsRepository
{
    GameSettings? Load();
    void Save(GameSettings settings);
}
