using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DominionProtocol.Domain.Model;

namespace DominionProtocol.Presentation.Presenter;

public interface IGameBoardView
{
    void DisplayPlayerStats(Player player);
    void DisplayOpponentSummaries(List<Player> opponents);
    void DisplayHand(List<Card> hand);
    Task<Card> WaitForCardSelection(List<Card> hand);
    void RefreshUI(List<Player> players);
    Card? SelectedCard { get; }
    void SetUseCardButtonEnabled(bool enabled);
    void SetRollDiceButtonEnabled(bool enabled);
    void ClearCardSelection();
    void ShowCutSceneMessage(string message);
    void ShowQuickMessage(string message);
    event Action RollDicePressed;
    event Action UseCardPressed;
}
