using System;
using System.Linq;
using DominionProtocol.Domain.Model;
using DominionProtocol.Domain.Repository;
using DominionProtocol.Domain.Service;
using System.Threading.Tasks;
using DominionProtocol.Domain.UseCase;

namespace DominionProtocol.Presentation.Presenter;

public class StartGameMenuPresenter
{
    private readonly IStartGameMenuView _view;
    private readonly IStartMatchUseCase _useCase;
    private readonly GenerateIntroService _introService;
    private readonly INationRepository _nationRepository;

    public StartGameMenuPresenter(IStartGameMenuView view, GenerateIntroService introService, INationRepository nationRepository, IStartMatchUseCase useCase)
    {
        _view = view;
        _introService = introService;
        _nationRepository = nationRepository;
        _useCase = useCase;
    }

    public async Task LoadSummary()
    {
        var era = GameSettings.SelectedPeriod.ToString();
        var nation = GameSettings.SelectedNation;

        var nations = await _nationRepository.GetAvailableForPeriod(GameSettings.SelectedPeriod);
        var opponents = nations
            .Where(n => n.Name != nation.Name)
            .Take(2)
            .ToList();

        _view.DisplaySummary(
            era,
            nation.Name,
            opponents.Select(o => o.Name).ToList()
        );

        var narrative = await _introService.Generate(nation, opponents);
        _view.DisplayContext(narrative.Text);
    }

    public async Task StartMatch()
    {
        var game = await _useCase.Start(GameSettings.SelectedPeriod, GameSettings.SelectedNation);
        GameSession.Current = game;
        _view.NavigateToGameBoard();
    }

}
