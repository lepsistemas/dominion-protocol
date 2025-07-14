using Moq;
using DominionProtocol.Presentation.Presenter;
using DominionProtocol.Domain.Model;
using DominionProtocol.Domain.UseCase;

namespace DominionProtocol.Tests.Presentation.Presenter;

public class StartGameMenuPresenterTests
{
    [Fact]
    public async Task ShouldDisplaySummaryAndNarrativeWhenLoadingSummary()
    {
        // Arrange
        var viewMock = new Mock<IStartGameMenuView>();
        var useCaseMock = new Mock<IStartMatchUseCase>();

        var result = new StartMatchResult(
            game: new Game(new List<Player>()),
            periodName: "Medieval",
            playerNation: new Nation("Testland", "desc", "Red", new List<HistoricalPeriod>(), new NationAttributes(1, 1, 1, 1)),
            opponents: new List<Nation>
            {
                new Nation("Opponia", "desc", "Blue", new List<HistoricalPeriod>(), new NationAttributes(1, 1, 1, 1)),
                new Nation("Rivalia", "desc", "Green", new List<HistoricalPeriod>(), new NationAttributes(1, 1, 1, 1))
            },
            contextNarrative: "Intro text"
        );

        useCaseMock.Setup(u => u.Start()).ReturnsAsync(result);

        var presenter = new StartGameMenuPresenter(viewMock.Object, useCaseMock.Object);

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
    public void ShouldStartGameAndNavigateToGameBoard()
    {
        // Arrange
        var viewMock = new Mock<IStartGameMenuView>();
        var useCaseMock = new Mock<IStartMatchUseCase>();

        var presenter = new StartGameMenuPresenter(viewMock.Object, useCaseMock.Object);

        // Act
        presenter.StartMatch();

        // Assert
        viewMock.Verify(v => v.NavigateToGameBoard(), Times.Once);
    }

}
