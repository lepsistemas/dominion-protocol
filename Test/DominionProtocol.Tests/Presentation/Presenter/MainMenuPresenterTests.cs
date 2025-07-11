using Moq;
using DominionProtocol.Presentation.Presenter;
using DominionProtocol.Domain.Model;

namespace DominionProtocol.Tests.Presentation.Presenter;

public class MainMenuPresenterTests
{
    [Fact]
    public void ShouldSetSelectedPeriodAndNavigateWhenPeriodIsValid()
    {
        // Arrange
        var viewMock = new Mock<IMainMenu>();
        var presenter = new MainMenuPresenter(viewMock.Object);

        // Act
        presenter.SelectPeriod("Medieval");

        // Assert
        Assert.Equal(HistoricalPeriod.Medieval, GameSettings.SelectedPeriod);
        viewMock.Verify(v => v.NavigateToChooseNation(), Times.Once);
    }

    [Fact]
    public void ShouldNotNavigateWhenPeriodIsInvalid()
    {
        // Arrange
        var viewMock = new Mock<IMainMenu>();
        var presenter = new MainMenuPresenter(viewMock.Object);

        // Act
        presenter.SelectPeriod("Jurassic");

        // Assert
        viewMock.Verify(v => v.NavigateToChooseNation(), Times.Never);
    }
}
