using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DominionProtocol.Domain.Model;

namespace DominionProtocol.Domain.Service;

public class CpuPlayerInput : IPlayerInput
{
    private static readonly Random _rng = new();
    private readonly RandomDiceRollService _dice = new();

    public Task<Card> ChooseCard(List<Card> hand)
    {
        var choice = hand[_rng.Next(hand.Count)];
        return Task.FromResult(choice);
    }

    public Task<int> RollDice()
    {
        return Task.FromResult(_dice.RollDice());
    }
}
