using Godot;
using System.Collections.Generic;
using DominionProtocol.Presentation.Presenter;
using DominionProtocol.Infra.Gateway;
using DominionProtocol.Domain.Service;

public partial class StartGameMenu : MarginContainer, IStartGameMenu
{
    private StartGameMenuPresenter _presenter = default!;

    public override async void _Ready()
    {
        var gateway = new LocalIntroGateway();
        var introService = new GenerateIntroService(gateway);
        _presenter = new StartGameMenuPresenter(this, introService);
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

    private async void OnStartMatchPressed()
    {
        await _presenter.StartMatch();
    }

    public void NavigateToGameBoard()
    {
        GetTree().ChangeSceneToFile("res://Game/Presentation/View/GameBoard.tscn");
    }
}
