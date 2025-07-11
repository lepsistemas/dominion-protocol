using Moq;
using DominionProtocol.Presentation.Presenter;
using DominionProtocol.Domain.Model;
using DominionProtocol.Domain.Service;
using DominionProtocol.Domain.Gateway;
using DominionProtocol.Domain.Repository;
using DominionProtocol.Domain.UseCase;

namespace DominionProtocol.Tests.Presentation.Presenter;

public class StartGameMenuPresenterTests
{
    [Fact]
    public async Task ShouldDisplaySummaryAndNarrativeWhenLoadingSummary()
    {
        // Arrange
        var viewMock = new Mock<IStartGameMenu>();
        var nationRepoMock = new Mock<INationRepository>();
        var useCaseMock = new Mock<IStartMatchUseCase>();

        var introGatewayMock = new Mock<IIntroGateway>();
        introGatewayMock
            .Setup(g => g.GenerateIntroText(It.IsAny<string>()))
            .ReturnsAsync(new IntroNarrative("Intro text"));

        var introService = new GenerateIntroService(introGatewayMock.Object);

        var presenter = new StartGameMenuPresenter(
            viewMock.Object,
            introService,
            nationRepoMock.Object,
            useCaseMock.Object
        );

        var selectedNation = new Nation(
            name: "Testland",
            description: "Test desc",
            startingStrength: 10,
            color: "Red",
            availablePeriods: new List<HistoricalPeriod> { HistoricalPeriod.Medieval },
            attributes: new NationAttributes(5, 5, 5, 5)
        );

        var opponent1 = new Nation("Opponia", "desc", 10, "Blue", new List<HistoricalPeriod> { HistoricalPeriod.Medieval }, new NationAttributes(3,3,3,3));
        var opponent2 = new Nation("Rivalia", "desc", 10, "Green", new List<HistoricalPeriod> { HistoricalPeriod.Medieval }, new NationAttributes(3,3,3,3));

        nationRepoMock
            .Setup(r => r.GetAvailableForPeriod(HistoricalPeriod.Medieval))
            .ReturnsAsync(new List<Nation> { selectedNation, opponent1, opponent2 });

        GameSettings.SetPeriod(HistoricalPeriod.Medieval);
        GameSettings.SetNation(selectedNation);

        // Act
        await presenter.LoadSummary();

        // Assert
        viewMock.Verify(v => v.DisplaySummary(
            "Medieval",
            "Testland",
            It.Is<List<string>>(list => list.Contains("Opponia") && list.Contains("Rivalia"))
        ), Times.Once);

        viewMock.Verify(v => v.DisplayContext("Intro text"), Times.Once);
    }

    [Fact]
    public async Task ShouldStartGameAndNavigateToGameBoard()
    {
        // Arrange
        var viewMock = new Mock<IStartGameMenu>();
        var nationRepoMock = new Mock<INationRepository>();
        var useCaseMock = new Mock<IStartMatchUseCase>();

        var introGatewayMock = new Mock<IIntroGateway>();
        var introService = new GenerateIntroService(introGatewayMock.Object);

        var presenter = new StartGameMenuPresenter(
            viewMock.Object,
            introService,
            nationRepoMock.Object,
            useCaseMock.Object
        );

        var selectedNation = new Nation(
            name: "Testland",
            description: "Test desc",
            startingStrength: 10,
            color: "Red",
            availablePeriods: new List<HistoricalPeriod> { HistoricalPeriod.Medieval },
            attributes: new NationAttributes(5, 5, 5, 5)
        );

        GameSettings.SetPeriod(HistoricalPeriod.Medieval);
        GameSettings.SetNation(selectedNation);

        useCaseMock
            .Setup(u => u.Start(It.IsAny<HistoricalPeriod>(), It.IsAny<Nation>()))
            .ReturnsAsync(new Game(new List<Player>()));

        // Act
        await presenter.StartMatch();

        // Assert
        Assert.NotNull(GameSession.Current);
        viewMock.Verify(v => v.NavigateToGameBoard(), Times.Once);
    }
}
