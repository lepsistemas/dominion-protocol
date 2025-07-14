using System;

namespace DominionProtocol.Domain.Service;

public class RandomDiceRollService : IDiceRollService
{
    private readonly Random _rng = new();

    public int Roll(int sides) => _rng.Next(1, sides + 1);
}
