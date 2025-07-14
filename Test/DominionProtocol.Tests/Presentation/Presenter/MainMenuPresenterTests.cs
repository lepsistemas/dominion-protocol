using Moq;
using DominionProtocol.Presentation.Presenter;
using DominionProtocol.Domain.Model;
using DominionProtocol.Domain.UseCase;

namespace DominionProtocol.Tests.Presentation.Presenter;

public class MainMenuPresenterTests
{
    [Fact]
    public void ShouldSetSelectedPeriodAndNavigateWhenPeriodIsValid()
    {
        // Arrange
        var viewMock = new Mock<IMainMenuView>();
        var useCaseMock = new Mock<IChooseHistoricalPeriodUseCase>();
        var presenter = new MainMenuPresenter(viewMock.Object, useCaseMock.Object);

        // Act
        presenter.SelectPeriod("Medieval");

        // Assert
        useCaseMock.Verify(u => u.Execute(HistoricalPeriod.Medieval), Times.Once);
        viewMock.Verify(v => v.NavigateToChooseNation(), Times.Once);
    }

    [Fact]
    public void ShouldNotNavigateWhenPeriodIsInvalid()
    {
        // Arrange
        var viewMock = new Mock<IMainMenuView>();
        var useCaseMock = new Mock<IChooseHistoricalPeriodUseCase>();
        var presenter = new MainMenuPresenter(viewMock.Object, useCaseMock.Object);

        // Act
        presenter.SelectPeriod("Jurassic");

        // Assert
        useCaseMock.Verify(u => u.Execute(It.IsAny<HistoricalPeriod>()), Times.Never);
        viewMock.Verify(v => v.NavigateToChooseNation(), Times.Never);
    }
}
