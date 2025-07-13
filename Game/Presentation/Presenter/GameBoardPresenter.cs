using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using DominionProtocol.Domain.Model;
using DominionProtocol.Domain.Service;
using DominionProtocol.Domain.UseCase;
using System;

namespace DominionProtocol.Presentation.Presenter;

public class GameBoardPresenter
{
    private readonly IGameBoard _view;

    private readonly RandomDiceRollService _diceRollService;

    private readonly ApplyCardEffectUseCase _applyCardEffect;

    private readonly PlaySingleTurnUseCase _playTurn;

    private readonly Dictionary<Player, IPlayerInput> _inputMap = [];

    private int _currentDiceRoll = 0;

    public GameBoardPresenter(IGameBoard view)
    {
        _view = view;
        _diceRollService = new RandomDiceRollService();
        var cardEffectService = new CardEffectService();
        _applyCardEffect = new ApplyCardEffectUseCase(cardEffectService);
        _playTurn = new PlaySingleTurnUseCase(_applyCardEffect);

        _view.RollDicePressed += OnRollDicePressed;
        _view.UseCardPressed += OnUseCardPressed;
    }

    public void Load()
    {
        var game = GameSession.Current;
        var player = game.Players.First(p => p.IsHuman);
        var opponents = game.Players.Where(p => !p.IsHuman).ToList();

        _inputMap[player] = new HumanPlayerInput(
            chooseCard: (hand) => Task.FromResult(_view.SelectedCard!),
            rollDice: () => Task.FromResult(_currentDiceRoll)
        );

        foreach (var cpu in opponents)
            _inputMap[cpu] = new CpuPlayerInput();

        _view.RefreshUI(game.Players);

        _view.ShowCutSceneMessage("Seu turno vai começar! Prepare-se pra rolar o dado...");
    }

    public void OnRollDicePressed()
    {
        _currentDiceRoll = _diceRollService.RollDice();
        _view.ShowCutSceneMessage($"Você rolou {_currentDiceRoll}. Agora escolha uma carta.");
        _view.SetRollDiceButtonEnabled(false);
    }

    public async void OnUseCardPressed()
    {
        if (_currentDiceRoll == 0)
        {
            _view.ShowQuickMessage("Role o dado antes de usar uma carta.");
            return;
        }

        if (_view.SelectedCard is not { } selected)
        {
            _view.ShowQuickMessage("Escolha uma carta antes de usar.");
            return;
        }

        var player = GetHumanPlayer();
        try
        {
            _view.ShowCutSceneMessage($"Você usou: {selected.Name}");
            await _playTurn.Execute(GameSession.Current, player, _inputMap[player]);

            _view.ClearCardSelection();
            _view.RefreshUI(GameSession.Current.Players);
            await Task.Delay(1000);

            _currentDiceRoll = 0;
            await PlayCpuTurns();
        }
        catch (InvalidOperationException ex)
        {
            _view.ShowCutSceneMessage(ex.Message);
        }
        catch (Exception ex)
        {
            _view.ShowQuickMessage("Ocorreu um erro. Tente novamente.");
        }
    }

    public bool IsCardSelectionEnabled => _currentDiceRoll > 0;

    private async Task PlayCpuTurns()
    {
        _view.ShowQuickMessage("Aguardando outros jogadores...");

        foreach (var cpu in GetCpuPlayers())
        {
            var input = _inputMap[cpu];
            await _playTurn.Execute(GameSession.Current, cpu, input);

            _view.RefreshUI(GameSession.Current.Players);
            await Task.Delay(1000);
        }

        _view.ShowCutSceneMessage("Seu turno começou! Role o dado.");
        _view.SetRollDiceButtonEnabled(true);
        Load();
    }

    private Player GetHumanPlayer() =>
        GameSession.Current.Players.First(p => p.IsHuman);

    private List<Player> GetCpuPlayers() =>
        GameSession.Current.Players.Where(p => !p.IsHuman).ToList();
}
