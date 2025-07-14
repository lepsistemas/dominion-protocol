using DominionProtocol.Domain.Model;
using System.Collections.Generic;
using System;

namespace DominionProtocol.Domain.Service;

public class CardEffectService : ICardEffectService
{
    private readonly Dictionary<CardType, ICardEffectStrategy> _strategies;

    public CardEffectService()
    {
        _strategies = new Dictionary<CardType, ICardEffectStrategy>
        {
            { CardType.Boost, new BoostEffectStrategy() },
            { CardType.Action, new ActionEffectStrategy() },
            { CardType.Event, new EventEffectStrategy() },
        };
    }

    public void Apply(Card card, Player self, List<Player> opponents, Game game, int diceRoll)
    {
        if (_strategies.TryGetValue(card.Type, out var strategy))
        {
            strategy.Apply(card, self, opponents, game, diceRoll);
        }
        else
        {
            throw new InvalidOperationException($"No strategy defined for card type {card.Type}");
        }
    }
}
