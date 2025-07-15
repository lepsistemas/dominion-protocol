using System;
using System.Collections.Generic;
using System.Linq;
using DominionProtocol.Domain.Model;

namespace DominionProtocol.Domain.Service;

public class BalancedCardPoolService : ICardPoolService
{
    private readonly Random _rng = new();

    public List<Card> GenerateStartingHand(Nation nation, List<Card> pool, int handSize = 5)
    {
        var militaryBias = nation.Attributes.Military;
        var techBias = nation.Attributes.Technology;
        var diplomacyBias = nation.Attributes.Diplomacy;

        var actions = pool.Where(c => c.Type == CardType.Action).ToList();
        var boosts = pool.Where(c => c.Type == CardType.Boost).ToList();
        var events = pool.Where(c => c.Type == CardType.Event).ToList();

        var hand = new List<Card>();

        int numActions = (militaryBias >= 80) ? 3 : (militaryBias >= 60 ? 2 : 1);
        int numBoosts = (techBias >= 80 || diplomacyBias >= 80) ? 2 : 1;
        int numEvents = 1;

        hand.AddRange(actions.OrderBy(_ => _rng.Next()).Take(numActions));
        hand.AddRange(boosts.OrderBy(_ => _rng.Next()).Take(numBoosts));
        hand.AddRange(events.OrderBy(_ => _rng.Next()).Take(numEvents));

        while (hand.Count < handSize)
        {
            var filler = pool.OrderBy(_ => _rng.Next()).First();
            if (!hand.Contains(filler))
                hand.Add(filler);
        }

        return hand.Take(handSize).ToList();
    }
}
