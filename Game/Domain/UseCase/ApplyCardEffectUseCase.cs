using System.Collections.Generic;
using DominionProtocol.Domain.Model;
using DominionProtocol.Domain.Service;

namespace DominionProtocol.Domain.UseCases;

public class ApplyCardEffectUseCase
{
    private readonly CardEffectService _effectService;

    public ApplyCardEffectUseCase(CardEffectService effectService)
    {
        _effectService = effectService;
    }

    public void Apply(Card card, Player self, List<Player> opponents, Game game, int diceRoll)
    {
        _effectService.Apply(card, self, opponents, game, diceRoll);
    }
}
