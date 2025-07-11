using System.Collections.Generic;
using System.Threading.Tasks;
using DominionProtocol.Domain.Model;

namespace DominionProtocol.Domain.Service;

public interface IPlayerInput
{
    Task<Card> ChooseCard(List<Card> hand);
    Task<int> RollDice();
}
