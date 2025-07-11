using System;
using System.Collections.Generic;

namespace DominionProtocol.Domain.Model;

public class Player
{
    public Guid Id { get; }
    public string Name { get; }
    public Nation Nation { get; }
    public bool IsHuman { get; }
    public List<Card> Hand { get; }

    public Player(string name, Nation nation, bool isHuman)
    {
        Id = Guid.NewGuid();
        Name = name;
        Nation = nation;
        IsHuman = isHuman;
        Hand = new List<Card>();
    }

    public void AddCard(Card card)
    {
        Hand.Add(card);
    }
}
