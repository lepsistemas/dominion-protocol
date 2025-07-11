using System;
using System.Linq;
using DominionProtocol.Domain.Model;
using DominionProtocol.Domain.Repository;
using DominionProtocol.Domain.UseCases;
using DominionProtocol.Infra.Repository;
using DominionProtocol.Domain.Service;
using System.Threading.Tasks;

namespace DominionProtocol.Presentation.Presenter;

public class StartGameMenuPresenter
{
    private readonly IStartGameMenu _view;
    private readonly StartMatchUseCase _useCase;
    private readonly GenerateIntroService _introService;
    private readonly INationRepository _nationRepository;
    private readonly ICardRepository _cardRepository;

    public StartGameMenuPresenter(IStartGameMenu view, GenerateIntroService introService)
    {
        _view = view;
        _introService = introService;

        _nationRepository = new InMemoryNationRepository();
        _cardRepository = new InMemoryCardRepository();
        _useCase = new StartMatchUseCase(_nationRepository, _cardRepository);
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
