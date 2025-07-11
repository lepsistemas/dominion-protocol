using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using DominionProtocol.Domain.Model;
using DominionProtocol.Domain.Repository;
using System.Threading.Tasks;

namespace DominionProtocol.Domain.UseCases;

public class StartMatchUseCase
{
    private readonly INationRepository _nationRepository;
    private readonly ICardRepository _cardRepository;

    public StartMatchUseCase(INationRepository nationRepository, ICardRepository cardRepository)
    {
        _nationRepository = nationRepository;
        _cardRepository = cardRepository;
    }

    public async Task<Game> Start(HistoricalPeriod period, Nation humanNation)
    {
        var all = await _nationRepository.GetAvailableForPeriod(period);
        var aiNations = all.Where(n => n.Name != humanNation.Name).ToList();

        var humanPlayer = new Player("Player 1", humanNation, true);

        var aiPlayers = aiNations
            .Take(2)
            .Select((nation, i) => new Player($"CPU {i + 1}", nation, false))
            .ToList();

        var allPlayers = new List<Player> { humanPlayer };
        allPlayers.AddRange(aiPlayers);

        var deck = await _cardRepository.GetAvailableForPeriod(period);
        var rng = new Random();
        foreach (var player in allPlayers)
        {
            var hand = deck.OrderBy(_ => rng.Next()).Take(5).ToList();
            foreach (var card in hand)
                player.AddCard(card);
            GD.Print($"{player.Name} hand: {string.Join(", ", player.Hand.Select(c => c.Name))}");
        }

        return new Game(allPlayers);
    }
}
