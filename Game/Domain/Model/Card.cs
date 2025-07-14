using System;
using System.Linq;

namespace DominionProtocol.Domain.Model;

public enum CardType
{
    Boost,
    Action,
    Event
}

public enum Rarity
{
    Common,
    Rare,
    Epic,
    Legendary
}

public enum TargetType
{
    Self,
    Enemy,
    AllPlayers,
    Random
}

public class Card
{
    public string Name { get; }
    public string Description { get; }
    public CardType Type { get; }
    public Rarity Rarity { get; }
    public TargetType Target { get; }
    public HistoricalPeriod[] AllowedPeriods { get; }
    public int MinDieValue { get; }

    public Card(
        string name,
        string description,
        CardType type,
        Rarity rarity,
        TargetType target,
        HistoricalPeriod[] allowedPeriods,
        int minDieValue = 1
    )
    {
        Name = name;
        Description = description;
        Type = type;
        Rarity = rarity;
        Target = target;
        AllowedPeriods = allowedPeriods;
        MinDieValue = minDieValue;
    }

    public bool IsAvailableIn(HistoricalPeriod period)
    {
        return AllowedPeriods.Contains(period);
    }
}
