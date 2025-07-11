using System.Collections.Generic;
using DominionProtocol.Domain.Model;

namespace DominionProtocol.Presentation.Presenter;

public interface IChooseNationMenu
{
    void DisplayNationOptions(List<Nation> nations);
    void NavigateToStartGame();
}
