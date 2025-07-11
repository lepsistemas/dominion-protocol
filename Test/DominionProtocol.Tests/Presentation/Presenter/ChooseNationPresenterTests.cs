using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using DominionProtocol.Presentation.Presenter;
using DominionProtocol.Domain.Model;
using DominionProtocol.Presentation;
using DominionProtocol.Infra.Repository;

namespace DominionProtocol.Tests.Presentation.Presenter;

public class ChooseNationPresenterTests
{
    [Fact]
    public async Task ShouldDisplayAvailableNationsWhenLoadingNationOptions()
    {
        // Arrange
        GameSettings.SetPeriod(HistoricalPeriod.Medieval);

        var viewMock = new Mock<IChooseNationMenu>();
        var presenter = new ChooseNationPresenter(viewMock.Object);

        // Act
        await presenter.LoadNationOptions();

        // Assert
        viewMock.Verify(v => v.DisplayNationOptions(It.Is<List<Nation>>(list => list.Count > 0)), Times.Once);
    }

    [Fact]
    public void ShouldSetSelectedNationAndNavigateToStartGame()
    {
        // Arrange
        var viewMock = new Mock<IChooseNationMenu>();
        var presenter = new ChooseNationPresenter(viewMock.Object);

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
        Assert.Equal(nation, GameSettings.SelectedNation);
        viewMock.Verify(v => v.NavigateToStartGame(), Times.Once);
    }
}
