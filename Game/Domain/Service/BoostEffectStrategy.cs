using DominionProtocol.Domain.Model;
using System.Collections.Generic;

namespace DominionProtocol.Domain.Service;

public class BoostEffectStrategy : ICardEffectStrategy
{
    public void Apply(Card card, Player self, List<Player> opponents, Game game, int diceRoll)
    {
        if (card.Name.Contains("Military"))
            self.Nation.BoostMilitary(diceRoll);
        else if (card.Name.Contains("Technology"))
            self.Nation.BoostTechnology(diceRoll);
        else if (card.Name.Contains("Resources"))
            self.Nation.BoostResources(diceRoll);
        else if (card.Name.Contains("Diplomacy"))
            self.Nation.BoostDiplomacy(diceRoll);
    }
}
