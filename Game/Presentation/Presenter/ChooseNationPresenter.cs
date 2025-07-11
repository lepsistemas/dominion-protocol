using System;
using DominionProtocol.Domain.Model;
using DominionProtocol.Domain.UseCases;
using DominionProtocol.Infra.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DominionProtocol.Presentation.Presenter;

public class ChooseNationPresenter
{
    private readonly IChooseNationMenu _view;
    private readonly ChooseNationUseCase _useCase;

    public ChooseNationPresenter(IChooseNationMenu view)
    {
        _view = view;
        _useCase = new ChooseNationUseCase(new InMemoryNationRepository());
    }

    public async Task LoadNationOptions()
    {
        var selectedEra = GameSettings.SelectedPeriod;
        List<Nation> nations = await _useCase.GetAvailableNations(selectedEra);
        _view.DisplayNationOptions(nations);
    }

    public void SelectNation(Nation nation)
    {
        GameSettings.SetNation(nation);
        _view.NavigateToStartGame();
    }
}
