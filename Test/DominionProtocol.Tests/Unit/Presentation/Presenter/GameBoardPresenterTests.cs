using Moq;
using DominionProtocol.Domain.Model;
using DominionProtocol.Domain.UseCase;
using DominionProtocol.Domain.Service;
using DominionProtocol.Presentation.Presenter;

namespace DominionProtocol.Tests.Presentation.Presenter;

public class GameBoardPresenterTests
{
    private readonly Mock<IGameBoardView> _viewMock;
    private readonly Mock<IDiceRollService> _diceServiceMock;
    private readonly Mock<IPlayFullTurnUseCase> _playTurnUseCaseMock;
    private readonly Mock<IGameSessionService> _gameSessionMock;
    private readonly Game _game;
    private readonly Player _humanPlayer;
    private readonly Card _testCard;

    public GameBoardPresenterTests()
    {
        _viewMock = new Mock<IGameBoardView>();
        _diceServiceMock = new Mock<IDiceRollService>();
        _playTurnUseCaseMock = new Mock<IPlayFullTurnUseCase>();
        _gameSessionMock = new Mock<IGameSessionService>();

        var nation = new Nation("Nation", "desc", "Red", new List<HistoricalPeriod>(), new NationAttributes(1, 1, 1, 1));
        _humanPlayer = new Player("Human", nation, isHuman: true);
        _testCard = new Card(
            name: "Attack",
            description: "Attack description",
            type: CardType.Action,
            rarity: Rarity.Common,
            target: TargetType.Enemy,
            allowedPeriods: [HistoricalPeriod.Medieval],
            minDieValue: 1
        );
        _humanPlayer.AddCard(_testCard);

        _game = new Game(new List<Player> { _humanPlayer });
        _gameSessionMock.Setup(g => g.GetCurrent()).Returns(_game);
    }

    [Fact]
    public void ShouldRefreshUIAndShowStartMessageWhenLoadingGame()
    {
        var presenter = CreatePresenter();

        presenter.Load();

        _viewMock.Verify(v => v.RefreshUI(_game.Players), Times.Once);
        _viewMock.Verify(v => v.ShowCutSceneMessage("Seu turno vai começar! Prepare-se pra rolar o dado..."), Times.Once);
    }

    [Fact]
    public void ShouldRollDiceAndUpdateUIWhenPlayerPressesRoll()
    {
        var presenter = CreatePresenter();
        var rollResult = 4;
        _diceServiceMock.Setup(d => d.Roll(6)).Returns(rollResult);

        _viewMock.Raise(v => v.RollDicePressed += null);

        _viewMock.Verify(v => v.ShowCutSceneMessage($"Você rolou {rollResult}. Agora escolha uma carta."), Times.Once);
        _viewMock.Verify(v => v.SetRollDiceButtonEnabled(false), Times.Once);
    }

    [Fact]
    public void ShouldShowWarningIfPlayerTriesToUseCardBeforeRollingDice()
    {
        var presenter = CreatePresenter();

        _viewMock.Raise(v => v.UseCardPressed += null);

        _viewMock.Verify(v => v.ShowQuickMessage("Role o dado antes de usar uma carta."), Times.Once);
    }

    [Fact]
    public void ShouldShowWarningIfPlayerTriesToUseCardWithoutSelectingAny()
    {
        var presenter = CreatePresenter();

        _diceServiceMock.Setup(d => d.Roll(6)).Returns(6);
        _viewMock.Raise(v => v.RollDicePressed += null);
        _viewMock.Setup(v => v.SelectedCard).Returns((Card?)null);

        _viewMock.Raise(v => v.UseCardPressed += null);

        _viewMock.Verify(v => v.ShowQuickMessage("Escolha uma carta antes de usar."), Times.Once);
    }

    [Fact]
    public async Task ShouldExecuteFullTurnAndUpdateUIWhenCardIsUsedCorrectly()
    {
        var presenter = CreatePresenter();

        _diceServiceMock.Setup(d => d.Roll(6)).Returns(6);
        _viewMock.Raise(v => v.RollDicePressed += null);
        _viewMock.Setup(v => v.SelectedCard).Returns(_testCard);

        _playTurnUseCaseMock
            .Setup(u => u.Execute(It.IsAny<PlayFullTurnInput>()))
            .Returns<PlayFullTurnInput>(async input =>
            {
                await input.OnCutscene("Usando carta");
                await input.OnUpdateUI();
            });

        _viewMock.Raise(v => v.UseCardPressed += null);
        await Task.Delay(10);

        _playTurnUseCaseMock.Verify(u => u.Execute(It.IsAny<PlayFullTurnInput>()), Times.Once);
        _viewMock.Verify(v => v.ClearCardSelection(), Times.Once);
        _viewMock.Verify(v => v.RefreshUI(_game.Players), Times.AtLeastOnce);
        _viewMock.Verify(v => v.SetRollDiceButtonEnabled(true), Times.Once);
    }

    private GameBoardPresenter CreatePresenter()
    {
        return new GameBoardPresenter(
            _viewMock.Object,
            _diceServiceMock.Object,
            _playTurnUseCaseMock.Object,
            _gameSessionMock.Object
        );
    }
}
