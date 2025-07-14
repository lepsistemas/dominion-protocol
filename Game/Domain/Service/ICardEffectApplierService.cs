namespace DominionProtocol.Domain.Service;

using System.Collections.Generic;
using DominionProtocol.Domain.Model;

public interface ICardEffectService
{
    void Apply(Card card, Player self, List<Player> opponents, Game game, int diceRoll);
}
