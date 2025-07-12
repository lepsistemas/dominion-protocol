using DominionProtocol.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using DominionProtocol.Domain.UseCase;

namespace DominionProtocol.Presentation.Presenter;

public class ChooseNationPresenter
{
    private readonly IChooseNationMenuView _view;
    private readonly IChooseNationUseCase _useCase;

    public ChooseNationPresenter(IChooseNationMenuView view, IChooseNationUseCase useCase)
    {
        _view = view;
        _useCase = useCase;
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
