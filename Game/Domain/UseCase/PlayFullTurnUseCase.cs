namespace DominionProtocol.Domain.UseCase;

using DominionProtocol.Domain.Service;
using System;
using System.Linq;
using System.Threading.Tasks;

public class PlayFullTurnUseCase : IPlayFullTurnUseCase
{
    private readonly ITurnExecutorService _turnExecutor;

    public PlayFullTurnUseCase(ITurnExecutorService turnExecutor)
    {
        _turnExecutor = turnExecutor;
    }

    public async Task Execute(PlayFullTurnInput input)
    {
        if (input.DiceRoll == 0)
            throw new InvalidOperationException("Dice not rolled");

        if (input.SelectedCard is null)
            throw new InvalidOperationException("No card selected");

        await input.OnCutscene($"Você usou: {input.SelectedCard.Name}");

        await _turnExecutor.Execute(input.CurrentGame, input.HumanPlayer,
            new HumanPlayerInput(
                chooseCard: _ => Task.FromResult(input.SelectedCard),
                rollDice: () => Task.FromResult(input.DiceRoll)
            ));

        await input.OnUpdateUI();
        await Task.Delay(1000);

        foreach (var cpu in input.CurrentGame.Players.Where(p => !p.IsHuman))
        {
            await _turnExecutor.Execute(input.CurrentGame, cpu, new CpuPlayerInput());
            await input.OnUpdateUI();
            await Task.Delay(1000);
        }

        await input.OnCutscene("Seu turno começou! Role o dado.");
    }
}
