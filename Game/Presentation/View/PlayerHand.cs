using Godot;
using System.Collections.Generic;
using DominionProtocol.Domain.Model;
using System.Linq;
using System;

public partial class PlayerHand : HBoxContainer
{
    private readonly List<CardView> _cardViews = new();

    public void Display(List<Card> cards, Action<Card> onCardClicked)
    {
        this.QueueFreeChildren();
        _cardViews.Clear();

        var cardScene = GD.Load<PackedScene>("res://Game/Presentation/Component/CardView.tscn");

        foreach (var card in cards)
        {
            if (cardScene.Instantiate() is CardView view)
            {
                view.SetCard(card, onCardClicked);
                _cardViews.Add(view);
                AddChild(view);
            }
        }
    }

    public CardView? FindCardView(Card card)
    {
        return GetChildren()
            .Cast<Node>()
            .OfType<CardView>()
            .FirstOrDefault(view => view.GetCard().Equals(card));
    }

}

public static class NodeExtensions
{
    public static void QueueFreeChildren(this Node node)
    {
        foreach (var child in node.GetChildren())
            child.QueueFree();
    }
}
