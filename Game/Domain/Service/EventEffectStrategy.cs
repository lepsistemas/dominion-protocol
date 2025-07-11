using DominionProtocol.Domain.Model;
using System.Collections.Generic;

namespace DominionProtocol.Domain.Service;

public class EventEffectStrategy : ICardEffectStrategy
{
    public void Apply(Card card, Player self, List<Player> opponents, Game game, int diceRoll)
    {
        var allPlayers = game.Players;
        foreach (var player in allPlayers)
        {
            if (player.Nation.Attributes.Technology < 5)
            {
                player.Nation.ReduceAllAttributes(1);
            }
        }
    }
}
