using System.Collections.Generic;

namespace DominionProtocol.Domain.Model;

public class Game
{
    public List<Player> Players { get; }
    public int CurrentTurnIndex { get; private set; }

    public Game(List<Player> players)
    {
        Players = players;
        CurrentTurnIndex = 0;
    }

    public Player GetCurrentPlayer() => Players[CurrentTurnIndex];

    public void NextTurn()
    {
        CurrentTurnIndex = (CurrentTurnIndex + 1) % Players.Count;
    }
}
