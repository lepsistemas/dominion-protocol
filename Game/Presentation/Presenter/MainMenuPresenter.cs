using System;
using DominionProtocol.Domain.Model;
using DominionProtocol.Domain.UseCase;

namespace DominionProtocol.Presentation.Presenter;

public class MainMenuPresenter
{
    private readonly IMainMenuView _view;
    private readonly ISetPeriodUseCase _useCase;

    public MainMenuPresenter(IMainMenuView view, ISetPeriodUseCase useCase)
    {
        _view = view;
        _useCase = useCase;
    }

    public void SelectPeriod(string label)
    {
        if (Enum.TryParse<HistoricalPeriod>(label, out var period))
        {
            _useCase.Execute(period);
            _view.NavigateToChooseNation();
        }
    }
}
