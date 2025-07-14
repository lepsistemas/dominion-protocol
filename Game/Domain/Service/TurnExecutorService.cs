using DominionProtocol.Domain.Model;
using System.Linq;
using System.Threading.Tasks;

namespace DominionProtocol.Domain.Service;

public class TurnExecutorService : ITurnExecutorService
{
    private readonly ICardEffectService _cardEffectService;

    public TurnExecutorService(ICardEffectService cardEffectService)
    {
        _cardEffectService = cardEffectService;
    }

    public async Task Execute(Game game, Player player, IPlayerInput input)
    {
        var card = await input.ChooseCard(player.Hand);
        var diceRoll = await input.RollDice();
        var opponents = game.Players.Where(p => !p.Equals(player)).ToList();

        _cardEffectService.Apply(card, player, opponents, game, diceRoll);
        player.Hand.Remove(card);
    }
}
