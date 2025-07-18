using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DominionProtocol.Domain.Model;
using DominionProtocol.Domain.Repository;
using DominionProtocol.Domain.Service;

namespace DominionProtocol.Domain.UseCase;

public class StartMatchUseCase : IStartMatchUseCase
{
    private readonly INationRepository _nationRepository;
    private readonly ICardRepository _cardRepository;
    private readonly IGameSessionRepository _sessionRepository;
    private readonly IGameSettingsRepository _settingsRepository;
    private readonly ICardPoolService _cardPoolService;
    private readonly GenerateIntroService _introService;

    public StartMatchUseCase(INationRepository nationRepository, ICardRepository cardRepository, IGameSessionRepository sessionRepository, IGameSettingsRepository settingsRepository, ICardPoolService cardPoolService, GenerateIntroService introService)
    {
        _nationRepository = nationRepository;
        _cardRepository = cardRepository;
        _sessionRepository = sessionRepository;
        _settingsRepository = settingsRepository;
        _cardPoolService = cardPoolService;
        _introService = introService;
    }

    public async Task<StartMatchResult> Start()
    {
        var settings = _settingsRepository.Load();
        if (settings == null)
            throw new InvalidOperationException("Game settings not initialized.");

        if (settings.Period is not HistoricalPeriod period)
            throw new InvalidOperationException("Period undefined.");

        if (settings.Nation is not Nation humanNation)
            throw new InvalidOperationException("Nation undefined.");

        var allNations = await _nationRepository.GetAvailableForPeriod(period);
        var aiNations = allNations.Where(n => n.Name != humanNation.Name).Take(2).ToList();

        var humanPlayer = new Player("Player 1", humanNation, true);

        var aiPlayers = aiNations
            .Select((nation, i) => new Player($"CPU {i + 1}", nation, false))
            .ToList();

        var allPlayers = new List<Player> { humanPlayer };
        allPlayers.AddRange(aiPlayers);

        var deck = await _cardRepository.GetAvailableForPeriod(period);
        var rng = new Random();

        foreach (var player in allPlayers)
        {
            var hand = _cardPoolService.GenerateStartingHand(player.Nation, deck, handSize: 5);
            foreach (var card in hand)
                player.AddCard(card);
        }

        var intro = await _introService.Generate(humanNation, aiNations);
        var game = new Game(allPlayers);
        GameSession.Current = game;

        _sessionRepository.Save(game);

        return new StartMatchResult(
            game: game,
            periodName: period.ToString(),
            playerNation: humanNation,
            opponents: aiNations,
            contextNarrative: intro.Text
        );
    }
}
