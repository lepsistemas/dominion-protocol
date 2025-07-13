using Moq;
using DominionProtocol.Presentation.Presenter;
using DominionProtocol.Domain.Model;
using DominionProtocol.Domain.UseCase;

namespace DominionProtocol.Tests.Presentation.Presenter;

public class ChooseNationPresenterTests
{
    [Fact]
    public async Task ShouldDisplayAvailableNationsWhenLoadingNationOptions()
    {
        // Arrange
        var viewMock = new Mock<IChooseNationMenuView>();
        var useCaseMock = new Mock<IChooseNationUseCase>();

        var nationList = new List<Nation>
        {
            new Nation(
                name: "Testland",
                description: "Test desc",
                startingStrength: 10,
                color: "Red",
                availablePeriods: new List<HistoricalPeriod> { HistoricalPeriod.Medieval },
                attributes: new NationAttributes(5, 5, 5, 5)
            )
        };

        useCaseMock
            .Setup(u => u.GetAvailableNations())
            .ReturnsAsync(nationList);

        var presenter = new ChooseNationPresenter(viewMock.Object, useCaseMock.Object);

        // Act
        await presenter.LoadNationOptions();

        // Assert
        viewMock.Verify(v => v.DisplayNationOptions(It.Is<List<Nation>>(list => list.SequenceEqual(nationList))), Times.Once);
    }

    [Fact]
    public void ShouldSetSelectedNationAndNavigateToStartGame()
    {
        // Arrange
        var viewMock = new Mock<IChooseNationMenuView>();
        var useCaseMock = new Mock<IChooseNationUseCase>();
        var presenter = new ChooseNationPresenter(viewMock.Object, useCaseMock.Object);

        var nation = new Nation(
            name: "Testland",
            description: "A brave test nation.",
            startingStrength: 10,
            color: "Red",
            availablePeriods: new List<HistoricalPeriod> { HistoricalPeriod.Medieval },
            attributes: new NationAttributes(military: 5, technology: 3, resources: 4, diplomacy: 2)
        );

        // Act
        presenter.SelectNation(nation);

        // Assert
        useCaseMock.Verify(u => u.SelectNation(nation), Times.Once);
        viewMock.Verify(v => v.NavigateToStartGame(), Times.Once);
    }
}
