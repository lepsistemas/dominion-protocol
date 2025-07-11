namespace DominionProtocol.Domain.Model;

public enum CardType
{
    Boost,
    Action,
    Event
}

public class Card
{
    public string Name { get; }
    public string Description { get; }
    public CardType Type { get; }

    public Card(string name, string description, CardType type)
    {
        Name = name;
        Description = description;
        Type = type;
    }
}
