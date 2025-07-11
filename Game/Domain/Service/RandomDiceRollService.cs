using System;

namespace DominionProtocol.Domain.Service;

public class RandomDiceRollService
{
    private readonly Random _rng = new();

    public int RollDice(int sides = 6) => _rng.Next(1, sides + 1);
}
