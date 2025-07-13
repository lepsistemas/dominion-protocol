using System.Linq;
using System.Threading.Tasks;
using DominionProtocol.Domain.UseCase;

namespace DominionProtocol.Presentation.Presenter;

public class StartGameMenuPresenter
{
    private readonly IStartGameMenuView _view;
    private readonly IStartMatchUseCase _useCase;

    public StartGameMenuPresenter(IStartGameMenuView view, IStartMatchUseCase useCase)
    {
        _view = view;
        _useCase = useCase;
    }

    public async Task LoadSummary()
    {
        var result = await _useCase.Start();

        _view.DisplaySummary(
            result.PeriodName,
            result.PlayerNation.Name,
            result.Opponents.Select(o => o.Name).ToList()
        );

        _view.DisplayContext(result.ContextNarrative);
    }

    public void StartMatch()
    {
        _view.NavigateToGameBoard();
    }

}
