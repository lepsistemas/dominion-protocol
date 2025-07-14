using DominionProtocol.Domain.Service;
using DominionProtocol.Infra.Gateway;
using DominionProtocol.Infra.Repository;
using DominionProtocol.Domain.UseCase;

namespace DominionProtocol.Presentation.Presenter;

public static class PresenterFactory
{
    public static MainMenuPresenter CreateMainMenuPresenter(IMainMenuView view)
    {
        var useCase = new ChooseHistoricalPeriodUseCase(RepositoryLocator.GameSettings);
        return new MainMenuPresenter(view, useCase);
    }

    public static ChooseNationPresenter CreateChooseNationPresenter(IChooseNationMenuView view)
    {
        var useCase = new ChooseNationUseCase(RepositoryLocator.Nations, RepositoryLocator.GameSettings);
        return new ChooseNationPresenter(view, useCase);
    }

    public static StartGameMenuPresenter CreateStartGameMenuPresenter(IStartGameMenuView view)
    {
        var gateway = new LocalIntroGateway();
        var introService = new GenerateIntroService(gateway);

        var useCase = new StartMatchUseCase(RepositoryLocator.Nations, RepositoryLocator.Cards, RepositoryLocator.GameSession, RepositoryLocator.GameSettings, introService);
        return new StartGameMenuPresenter(view, useCase);
    }

    public static GameBoardPresenter CreateGameBoardPresenter(IGameBoardView view)
    {
        var cardEffectService = new CardEffectService();
        var turnExecutor = new TurnExecutorService(cardEffectService);
        var useCase = new PlayFullTurnUseCase(turnExecutor);

        var diceRollService = new RandomDiceRollService();
        var gameSessionService = new GameSessionService(RepositoryLocator.GameSession);
        return new GameBoardPresenter(view, diceRollService, useCase, gameSessionService);
    }
}
