using DominionProtocol.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace DominionProtocol.Domain.Service;

public class ActionEffectStrategy : ICardEffectStrategy
{
    public void Apply(Card card, Player self, List<Player> opponents, Game game, int diceRoll)
    {
        var target = opponents.OrderBy(p => p.Nation.Attributes.Diplomacy).FirstOrDefault();
        if (target != null)
        {
            target.Nation.ReduceResources(diceRoll);
        }
    }
}
