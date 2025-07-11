using DominionProtocol.Domain.Service;
using DominionProtocol.Infra.Gateway;
using DominionProtocol.Infra.Repository;
using DominionProtocol.Domain.UseCase;

namespace DominionProtocol.Presentation.Presenter;

public static class PresenterFactory
{
    public static MainMenuPresenter CreateMainMenuPresenter(IMainMenu view)
    {
        return new MainMenuPresenter(view);
    }

    public static ChooseNationPresenter CreateChooseNationPresenter(IChooseNationMenu view)
    {
        var nationRepo = new InMemoryNationRepository();
        var useCase = new ChooseNationUseCase(nationRepo);
        return new ChooseNationPresenter(view, useCase);
    }

    public static StartGameMenuPresenter CreateStartGameMenuPresenter(IStartGameMenu view)
    {
        var gateway = new LocalIntroGateway();
        var introService = new GenerateIntroService(gateway);

        var nationRepo = new InMemoryNationRepository();
        var cardRepo = new InMemoryCardRepository();
        var useCase = new StartMatchUseCase(nationRepo, cardRepo);

        return new StartGameMenuPresenter(view, introService, nationRepo, useCase);
    }
}
