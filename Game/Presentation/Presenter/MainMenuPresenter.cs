using System;
using DominionProtocol.Domain.Model;

namespace DominionProtocol.Presentation.Presenter;

public class MainMenuPresenter
{
    private readonly IMainMenuView _view;

    public MainMenuPresenter(IMainMenuView view)
    {
        _view = view;
    }

    public void SelectPeriod(string label)
    {
        if (Enum.TryParse<HistoricalPeriod>(label, out var period))
        {
            GameSettings.SetPeriod(period);
            _view.NavigateToChooseNation();
        }
    }
}
