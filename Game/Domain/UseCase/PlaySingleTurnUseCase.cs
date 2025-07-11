using System.Threading.Tasks;
using System.Linq;
using DominionProtocol.Domain.Model;
using DominionProtocol.Domain.Service;
using DominionProtocol.Domain.UseCases;
using System;

public class PlaySingleTurnUseCase
{
    private readonly ApplyCardEffectUseCase _applyCardEffect;

    public PlaySingleTurnUseCase(ApplyCardEffectUseCase applyCardEffect)
    {
        _applyCardEffect = applyCardEffect;
    }

    public async Task Execute(Game game, Player player, IPlayerInput input)
    {
        var dice = await input.RollDice();
        if (dice <= 0)
            throw new InvalidOperationException("Você precisa rolar o dado antes de escolher uma carta.");

        var card = await input.ChooseCard(player.Hand);

        var opponents = game.Players.Where(p => p != player).ToList();
        _applyCardEffect.Apply(card, player, opponents, game, dice);
        player.Hand.Remove(card);
    }
}
