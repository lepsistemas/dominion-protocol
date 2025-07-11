using DominionProtocol.Domain.Model;
using System.Collections.Generic;

namespace DominionProtocol.Domain.Service;

public interface ICardEffectStrategy
{
    void Apply(Card card, Player self, List<Player> opponents, Game game, int diceRoll);
}
