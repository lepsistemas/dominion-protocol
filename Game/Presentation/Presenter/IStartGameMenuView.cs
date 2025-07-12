using System.Collections.Generic;

namespace DominionProtocol.Presentation.Presenter;

public interface IStartGameMenuView
{
    void DisplaySummary(string period, string playerNation, List<string> opponentNames);
    void DisplayContext(string text);
    void NavigateToGameBoard();
}
