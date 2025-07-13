using Godot;
using System.Collections.Generic;
using DominionProtocol.Presentation.Presenter;

namespace DominionProtocol.Presentation.View;

public partial class StartGameMenuView : MarginContainer, IStartGameMenuView
{
    private StartGameMenuPresenter _presenter = default!;

    public override async void _Ready()
    {
        _presenter = PresenterFactory.CreateStartGameMenuPresenter(this);
        await _presenter.LoadSummary();

        GetNode<Button>("ContentWrapper/MainContainer/StartContainer/StartButton").Pressed += OnStartMatchPressed;
    }

    public void DisplaySummary(string period, string playerNation, List<string> opponentNames)
    {
        GetNode<Label>("ContentWrapper/TitleContainer/SummaryContainer/PeriodLabel").Text = $"Period: {period}";
        GetNode<Label>("ContentWrapper/TitleContainer/SummaryContainer/PlayerNationLabel").Text = $"Your Nation: {playerNation}";
        GetNode<Label>("ContentWrapper/TitleContainer/SummaryContainer/OpponentsLabel").Text = $"Opponents: {string.Join(", ", opponentNames)}";
    }

    public void DisplayContext(string text)
    {
        GD.Print(text);
        GetNode<RichTextLabel>("ContentWrapper/TitleContainer/SummaryContainer/ContextContainer/CenterContextContainer/ContextWrapper/ContextPanel/ContextLabel").Text = text;
    }

    private void OnStartMatchPressed()
    {
        _presenter.StartMatch();
    }

    public void NavigateToGameBoard()
    {
        GetTree().ChangeSceneToFile("res://Game/Presentation/View/GameBoard.tscn");
    }
}
