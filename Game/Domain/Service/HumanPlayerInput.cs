using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DominionProtocol.Domain.Model;

namespace DominionProtocol.Domain.Service;

public class HumanPlayerInput : IPlayerInput
{
    private readonly Func<List<Card>, Task<Card>> _chooseCard;
    private readonly Func<Task<int>> _rollDice;

    public HumanPlayerInput(Func<List<Card>, Task<Card>> chooseCard, Func<Task<int>> rollDice)
    {
        _chooseCard = chooseCard;
        _rollDice = rollDice;
    }

    public Task<Card> ChooseCard(List<Card> hand)
    {
        return _chooseCard(hand);
    }

    public Task<int> RollDice()
    {
        return _rollDice();
    }
}
