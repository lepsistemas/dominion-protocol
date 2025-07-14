using Xunit;
using Moq;
using DominionProtocol.Domain.Model;
using DominionProtocol.Domain.UseCase;
using DominionProtocol.Domain.Repository;

namespace DominionProtocol.Tests.Domain.UseCase;

public class ChooseHistoricalPeriodUseCaseTests
{
    [Fact]
    public void ShouldSetHistoricalPeriodInGameSettings()
    {
        // Arrange
        var repositoryMock = new Mock<IGameSettingsRepository>();
        var existingSettings = new GameSettings();
        repositoryMock.Setup(r => r.Load()).Returns(existingSettings);

        var useCase = new ChooseHistoricalPeriodUseCase(repositoryMock.Object);
        var selectedPeriod = HistoricalPeriod.Medieval;

        // Act
        useCase.Execute(selectedPeriod);

        // Assert
        repositoryMock.Verify(r => r.Save(It.Is<GameSettings>(
            s => s.Period == selectedPeriod
        )), Times.Once);
    }

    [Fact]
    public void ShouldCreateNewSettingsIfNoneExist()
    {
        // Arrange
        var repositoryMock = new Mock<IGameSettingsRepository>();
        repositoryMock.Setup(r => r.Load()).Returns((GameSettings?)null);

        var useCase = new ChooseHistoricalPeriodUseCase(repositoryMock.Object);
        var selectedPeriod = HistoricalPeriod.Future;

        // Act
        useCase.Execute(selectedPeriod);

        // Assert
        repositoryMock.Verify(r => r.Save(It.Is<GameSettings>(
            s => s.Period == selectedPeriod
        )), Times.Once);
    }
}
