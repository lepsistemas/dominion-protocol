using Godot;
using DominionProtocol.Domain.Model;
using System;

namespace DominionProtocol.Presentation.View;

public partial class CardView : PanelContainer
{
    private const float HoverScale = 1.2f;
    private const float HoverYOffset = -50f;
    private const float TweenTime = 0.1f;

    private Tween? _hoverTween;
    private Vector2 _originalScale;
    private float _originalY;
    private Card _card = default!;
    private bool _isSelected = false;
    private bool _isBeingFreed = false;
    private Action<Card>? _onClicked;

    public override void _Ready()
    {
        _originalScale = Scale;
        _originalY = Position.Y;

        MouseEntered += OnMouseEntered;
        MouseExited += OnMouseExited;
    }

    public override void _ExitTree()
    {
        _isBeingFreed = true;
        MouseEntered -= OnMouseEntered;
        MouseExited -= OnMouseExited;
        _hoverTween?.Kill();
    }

    public void SetCard(Card card, Action<Card> onClicked)
    {
        _card = card;
        _onClicked = onClicked;

        GetNode<Label>("Content/Layout/ClassContainer/ClassLabel").Text = card.Type.ToString();
        GetNode<Label>("Content/Layout/NameContainer/NameLabel").Text = card.Name;
        GetNode<Label>("Content/Layout/DescriptionContainer/DescriptionLabel").Text = card.Description;

        var background = GetNode<TextureRect>("Background");
        background.Texture = GD.Load<Texture2D>("res://Assets/Images/Cards/Background_Front.png");

        switch (card.Type)
        {
            case CardType.Boost:
                background.Modulate = new Color(0.6f, 1.0f, 0.6f, 0.9f);
                break;
            case CardType.Action:
                background.Modulate = new Color(1.0f, 0.6f, 0.6f, 0.9f);
                break;
            case CardType.Event:
                background.Modulate = new Color(0.6f, 0.7f, 1.0f, 0.9f);
                break;
        }
    }

    public Card GetCard() => _card;

    private void OnMouseEntered()
    {
        if (!IsSafeToAnimate()) return;
        SetDefaultCursorShape(CursorShape.PointingHand);
        if (!_isSelected)
            ApplyHoverVisual();
    }

    private void OnMouseExited()
    {
        if (!IsSafeToAnimate()) return;
        if (!_isSelected)
            ResetDefaultVisual();
        SetDefaultCursorShape(CursorShape.Arrow);
    }

    public override void _GuiInput(InputEvent @event)
    {
        if (@event is InputEventMouseButton { Pressed: true })
        {
            _onClicked?.Invoke(_card); // a GameBoard cuidará de resetar as outras
        }
    }

    public void SetSelectedVisual()
    {
        _isSelected = true;
        ApplyHoverVisual();
    }

    public void ResetDefaultVisual()
    {
        _isSelected = false;

        if (!IsSafeToAnimate()) return;

        _hoverTween?.Kill();
        _hoverTween = CreateTween();
        _hoverTween.TweenProperty(this, "scale", _originalScale, TweenTime);
        _hoverTween.TweenProperty(this, "position:y", _originalY, TweenTime);
        ZIndex = 0;

        GetNode<TextureRect>("Background").SelfModulate = Colors.White;
    }

    private void ApplyHoverVisual()
    {
        if (!IsSafeToAnimate()) return;

        _hoverTween?.Kill();
        _hoverTween = CreateTween();
        _hoverTween.TweenProperty(this, "scale", new Vector2(HoverScale, HoverScale), TweenTime);
        _hoverTween.TweenProperty(this, "position:y", _originalY + HoverYOffset, TweenTime);
        ZIndex = 10;

        var background = GetNode<TextureRect>("Background");
        background.SelfModulate = new Color(1, 1, 1, 1.0f);
    }

    private bool IsSafeToAnimate() =>
        IsInstanceValid(this) && IsInsideTree() && !_isBeingFreed;
}
