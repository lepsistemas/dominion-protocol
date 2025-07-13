using Godot;
using DominionProtocol.Presentation.Presenter;

namespace DominionProtocol.Presentation.View;

public partial class MainMenuView : MarginContainer, IMainMenuView
{
    private MainMenuPresenter _presenter = default!;

    public override void _Ready()
    {
        DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
        DisplayServer.WindowSetFlag(DisplayServer.WindowFlags.Borderless, true);

        _presenter = PresenterFactory.CreateMainMenuPresenter(this);

        var container = GetNode<HBoxContainer>("ContentWrapper/MainContainer/PeriodButtonsContainer");
        container.GetNode<Button>("AncientButton").Pressed += () => _presenter.SelectPeriod("Ancient");
        container.GetNode<Button>("MedievalButton").Pressed += () => _presenter.SelectPeriod("Medieval");
        container.GetNode<Button>("ModernButton").Pressed += () => _presenter.SelectPeriod("Modern");
        container.GetNode<Button>("FutureButton").Pressed += () => _presenter.SelectPeriod("Future");
    }

    public void NavigateToChooseNation()
    {
        GetTree().ChangeSceneToFile("res://Game/Presentation/View/ChooseNationMenu.tscn");
    }
}
