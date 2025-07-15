using DominionProtocol.Presentation.View;
using Moq;

namespace DominionProtocol.Tests.Presentation.Presenter;

public class LoginPresenterTests
{
    [Fact]
    public void ShouldNavigateToMainMenuOnSignInSuccess()
    {
        // Arrange
        var viewMock = new Mock<ILoginView>();
        var presenter = new LoginPresenter(viewMock.Object);

        // Act
        presenter.OnSignInPressed("user", "pass");

        // Assert
        viewMock.Verify(v => v.NavigateToMainMenu(), Times.Once);
        viewMock.Verify(v => v.ShowError(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void ShouldNavigateToMainMenuOnSignUpSuccess()
    {
        // Arrange
        var viewMock = new Mock<ILoginView>();
        var presenter = new LoginPresenter(viewMock.Object);

        // Act
        presenter.OnSignUpPressed("user", "pass");

        // Assert
        viewMock.Verify(v => v.NavigateToMainMenu(), Times.Once);
        viewMock.Verify(v => v.ShowError(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void ShouldNavigateToMainMenuOnGuest()
    {
        // Arrange
        var viewMock = new Mock<ILoginView>();
        var presenter = new LoginPresenter(viewMock.Object);

        // Act
        presenter.OnGuestPressed();

        // Assert
        viewMock.Verify(v => v.NavigateToMainMenu(), Times.Once);
    }
}
