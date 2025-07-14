using Godot;
using DominionProtocol.Domain.Model;
using DominionProtocol.Presentation.Presenter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace DominionProtocol.Presentation.View;

public partial class GameBoardView : MarginContainer, IGameBoardView
{
    private GameBoardPresenter _presenter = default!;
    public Card? SelectedCard { get; private set; }
    private CardView? _selectedCardView;
    private TaskCompletionSource<Card>? _cardSelectionSource = default!;
    public event Action? RollDicePressed;
    public event Action? UseCardPressed;

    private Button _rollDiceButton = default!;
    private Button _useCardButton = default!;

    public override void _Ready()
    {
        _presenter = PresenterFactory.CreateGameBoardPresenter(this);
        _presenter.Load();

        _rollDiceButton = GetNode<Button>("ContentWrapper/MainLayout/BottomRow/ActionWrapper/ActionPanel/RollDiceButton");
        _useCardButton = GetNode<Button>("ContentWrapper/MainLayout/BottomRow/ActionWrapper/ActionPanel/UseCardButton");

        _rollDiceButton.Pressed += () => RollDicePressed?.Invoke();
        _useCardButton.Pressed += () => UseCardPressed?.Invoke();

        SetUseCardButtonEnabled(false);
    }

    public void DisplayPlayerStats(Player player)
    {
        var nationColor = player.Nation.Color;
        var nationName = player.Nation.Name;
        var labelText = $"[b]{player.Name}[/b] ([color={nationColor}]{nationName}[/color])";
        GetNode<RichTextLabel>("ContentWrapper/MainLayout/TopRow/StatsPanel/PlayerInfoLabel").Text = labelText;

        var attrs = player.Nation.Attributes;
        GetNode<Label>("ContentWrapper/MainLayout/TopRow/StatsPanel/MilitaryLabel").Text = $"Military: {attrs.Military}";
        GetNode<Label>("ContentWrapper/MainLayout/TopRow/StatsPanel/TechnologyLabel").Text = $"Technology: {attrs.Technology}";
        GetNode<Label>("ContentWrapper/MainLayout/TopRow/StatsPanel/ResourcesLabel").Text = $"Resources: {attrs.Resources}";
        GetNode<Label>("ContentWrapper/MainLayout/TopRow/StatsPanel/DiplomacyLabel").Text = $"Diplomacy: {attrs.Diplomacy}";
    }

    public void DisplayOpponentSummaries(List<Player> opponents)
    {
        var container = GetNode<VBoxContainer>("ContentWrapper/MainLayout/TopRow/EnemyPanel");
        container.QueueFreeChildren();
        foreach (var opponent in opponents)
        {
            var label = new Label
            {
                Text = $"{opponent.Name}: {opponent.Nation.Name}"
            };
            container.AddChild(label);
        }
    }

    public void DisplayHand(List<Card> hand)
    {
        var playerHand = GetNode<PlayerHand>("ContentWrapper/MainLayout/BottomRow/HandWrapper/HandControl/HandPanel");
        playerHand.Display(hand, OnCardClicked);
    }

    public Task<Card> WaitForCardSelection(List<Card> hand)
    {
        DisplayHand(hand);
        _cardSelectionSource = new TaskCompletionSource<Card>();
        return _cardSelectionSource.Task;
    }

    public void ClearCardSelection()
    {
        SelectedCard = null;
        _selectedCardView?.ResetDefaultVisual();
        _selectedCardView = null;
        SetUseCardButtonEnabled(false);

    }

    private void OnCardClicked(Card card)
    {
        if (!_presenter.IsCardSelectionEnabled)
        {
            ShowQuickMessage("Você precisa rolar o dado antes de escolher uma carta.");
            return;
        }

        if (SelectedCard == card)
        {
            ClearCardSelection();
            SetUseCardButtonEnabled(false);
            return;
        }

        if (IsInstanceValid(_selectedCardView))
            _selectedCardView?.ResetDefaultVisual();

        SelectedCard = card;

        var view = FindCardView(card);
        if (view is not null)
        {
            _selectedCardView = view;
            view.SetSelectedVisual();
        }

        SetUseCardButtonEnabled(true);
    }

    private CardView? FindCardView(Card card)
    {
        var playerHand = GetNode<PlayerHand>("ContentWrapper/MainLayout/BottomRow/HandWrapper/HandControl/HandPanel");
        return playerHand.FindCardView(card);
    }

    public void RefreshUI(List<Player> players)
    {
        var player = players.First(p => p.IsHuman);
        DisplayPlayerStats(player);
        DisplayHand(player.Hand);

        var opponents = players.Where(p => !p.IsHuman).ToList();
        DisplayOpponentSummaries(opponents);
    }

    public void SetUseCardButtonEnabled(bool enabled)
    {
        _useCardButton.Disabled = !enabled;
    }

    public void SetRollDiceButtonEnabled(bool enabled)
    {
        _rollDiceButton.Disabled = !enabled;
    }

    public async void ShowCutSceneMessage(string message)
    {
        var scene = GD.Load<PackedScene>("res://Game/Presentation/View/TurnStartCutScene.tscn");
        var instance = scene.Instantiate<TurnStartCutScene>();
        AddChild(instance);
        await instance.Play(message);
    }

    public void ShowQuickMessage(string message)
    {
        var label = GetNode<Label>("ContentWrapper/QuickMessageLabel");
        var tween = CreateTween();
        tween.TweenCallback(Callable.From(() => label.Text = message));
        tween.TweenInterval(2.0);
        tween.TweenCallback(Callable.From(() => label.Text = ""));
    }

}
