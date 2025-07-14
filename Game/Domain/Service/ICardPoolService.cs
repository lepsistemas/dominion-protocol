using System.Collections.Generic;
using DominionProtocol.Domain.Model;

namespace DominionProtocol.Domain.Service;

public interface ICardPoolService
{
    List<Card> GenerateStartingHand(Nation nation, List<Card> pool, int handSize = 5);
}
