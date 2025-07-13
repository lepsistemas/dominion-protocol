using Godot;
using System.Collections.Generic;
using DominionProtocol.Presentation.Presenter;
using DominionProtocol.Domain.Model;

namespace DominionProtocol.Presentation.View;

public partial class ChooseNationMenuView : MarginContainer, IChooseNationMenuView
{
    private ChooseNationPresenter _presenter = default!;

    public override async void _Ready()
    {
        _presenter = PresenterFactory.CreateChooseNationPresenter(this);
        await _presenter.LoadNationOptions();
    }

    public void DisplayNationOptions(List<Nation> nations)
    {
        var container = GetNode<HBoxContainer>("ContentWrapper/MainContainer/NationListContainer");

        foreach (var nation in nations)
        {
            var button = new Button
            {
                Text = nation.Name,
                TooltipText = nation.Description
            };

            button.Pressed += () => _presenter.SelectNation(nation);
            container.AddChild(button);
        }
    }

    public void NavigateToStartGame()
    {
        GetTree().ChangeSceneToFile("res://Game/Presentation/View/StartGameMenu.tscn");
    }
}
