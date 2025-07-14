using DominionProtocol.Domain.Model;
using DominionProtocol.Domain.UseCase;
using DominionProtocol.Domain.Service;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DominionProtocol.Presentation.Presenter;

public class GameBoardPresenter
{
    private readonly IGameBoardView _view;
    private readonly IDiceRollService _diceService;
    private readonly IPlayFullTurnUseCase _playFullTurnUseCase;
    private readonly IGameSessionService _gameSession;

    private int _currentDiceRoll = 0;

    public GameBoardPresenter(IGameBoardView view, IDiceRollService diceService, IPlayFullTurnUseCase playFullTurnUseCase, IGameSessionService gameSession)
    {
        _view = view;
        _diceService = diceService;
        _playFullTurnUseCase = playFullTurnUseCase;
        _gameSession = gameSession;

        _view.RollDicePressed += OnRollDicePressed;
        _view.UseCardPressed += OnUseCardPressed;
    }

    public void Load()
    {
        var game = _gameSession.GetCurrent();
        _view.RefreshUI(game.Players);
        _view.ShowCutSceneMessage("Seu turno vai começar! Prepare-se pra rolar o dado...");
    }

    private void OnRollDicePressed()
    {
        _currentDiceRoll = _diceService.Roll(6);
        _view.ShowCutSceneMessage($"Você rolou {_currentDiceRoll}. Agora escolha uma carta.");
        _view.SetRollDiceButtonEnabled(false);
    }

    private async void OnUseCardPressed()
    {
        if (_currentDiceRoll == 0)
        {
            _view.ShowQuickMessage("Role o dado antes de usar uma carta.");
            return;
        }

        if (_view.SelectedCard is not { } selectedCard)
        {
            _view.ShowQuickMessage("Escolha uma carta antes de usar.");
            return;
        }

        var game = _gameSession.GetCurrent();
        var human = game.Players.First(p => p.IsHuman);

        try
        {
            await _playFullTurnUseCase.Execute(new PlayFullTurnInput(
                CurrentGame: game,
                HumanPlayer: human,
                SelectedCard: selectedCard,
                DiceRoll: _currentDiceRoll,
                OnUpdateUI: () =>
                {
                    _view.ClearCardSelection();
                    _view.RefreshUI(game.Players);
                    return Task.CompletedTask;
                },
                OnCutscene: msg =>
                {
                    _view.ShowCutSceneMessage(msg);
                    return Task.CompletedTask;
                },
                OnQuickMessage: msg =>
                {
                    _view.ShowQuickMessage(msg);
                    return Task.CompletedTask;
                }
            ));

            _currentDiceRoll = 0;
            _view.SetRollDiceButtonEnabled(true);
        }
        catch (InvalidOperationException ex)
        {
            _view.ShowCutSceneMessage(ex.Message);
        }
        catch (Exception)
        {
            _view.ShowQuickMessage("Ocorreu um erro. Tente novamente.");
        }
    }

    public bool IsCardSelectionEnabled => _currentDiceRoll > 0;
}
