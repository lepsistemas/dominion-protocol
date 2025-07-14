using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using DominionProtocol.Domain.Model;
using DominionProtocol.Domain.Repository;

namespace DominionProtocol.Infra.Repository;

public class InMemoryCardRepository : ICardRepository
{
    private readonly List<Card> _cards = new()
    {
        new Card("Gladiator Training", "Military +10 for 1 turn",
            CardType.Boost, Rarity.Common, TargetType.Self,
            [HistoricalPeriod.Ancient], minDieValue: 2),

        new Card("Pyramid Engineering", "Technology +10",
            CardType.Boost, Rarity.Rare, TargetType.Self,
            [HistoricalPeriod.Ancient], minDieValue: 3),

        new Card("Harvest Festival", "Gain 15 Resources",
            CardType.Boost, Rarity.Common, TargetType.Self,
            [HistoricalPeriod.Ancient], minDieValue: 1),

        new Card("Chariot Assault", "Damage enemy Military -15",
            CardType.Action, Rarity.Rare, TargetType.Enemy,
            [HistoricalPeriod.Ancient], minDieValue: 4),

        new Card("Oracle's Prophecy", "See opponent hand",
            CardType.Action, Rarity.Common, TargetType.Enemy,
            [HistoricalPeriod.Ancient], minDieValue: 2),

        // --- Medieval Period ---
        new Card("Knight Parade", "Military +12 this turn",
            CardType.Boost, Rarity.Common, TargetType.Self,
            [HistoricalPeriod.Medieval], minDieValue: 2),

        new Card("Alchemy Discovery", "Technology +8, Resources +5",
            CardType.Boost, Rarity.Rare, TargetType.Self,
            [HistoricalPeriod.Medieval], minDieValue: 3),

        new Card("Monastery Blessing", "Diplomacy +10",
            CardType.Boost, Rarity.Common, TargetType.Self,
            [HistoricalPeriod.Medieval], minDieValue: 1),

        new Card("Inquisition", "Enemy loses 8 Diplomacy",
            CardType.Action, Rarity.Rare, TargetType.Enemy,
            [HistoricalPeriod.Medieval], minDieValue: 4),

        new Card("Siege", "Drain 10 Resources from one enemy",
            CardType.Action, Rarity.Rare, TargetType.Enemy,
            [HistoricalPeriod.Medieval], minDieValue: 3),

        new Card("Black Plague", "All players lose 5 of each stat",
            CardType.Event, Rarity.Epic, TargetType.AllPlayers,
            [HistoricalPeriod.Medieval], minDieValue: 5),

        // --- Modern Period ---
        new Card("Industrial Boom", "Resources +20",
            CardType.Boost, Rarity.Common, TargetType.Self,
            [HistoricalPeriod.Modern], minDieValue: 2),

        new Card("Cyber Initiative", "Technology +15",
            CardType.Boost, Rarity.Rare, TargetType.Self,
            [HistoricalPeriod.Modern], minDieValue: 4),

        new Card("Media Blitz", "Diplomacy +15",
            CardType.Boost, Rarity.Rare, TargetType.Self,
            [HistoricalPeriod.Modern], minDieValue: 2),

        new Card("Drone Strike", "Enemy loses 10 Military",
            CardType.Action, Rarity.Common, TargetType.Enemy,
            [HistoricalPeriod.Modern], minDieValue: 3),

        new Card("Trade Sanctions", "Enemy loses 12 Resources",
            CardType.Action, Rarity.Rare, TargetType.Enemy,
            [HistoricalPeriod.Modern], minDieValue: 5),

        new Card("Tech Fair", "All players gain 5 Tech",
            CardType.Event, Rarity.Common, TargetType.AllPlayers,
            [HistoricalPeriod.Modern], minDieValue: 1),

        // --- Future Period ---
        new Card("AI Upgrade", "Technology +25",
            CardType.Boost, Rarity.Epic, TargetType.Self,
            [HistoricalPeriod.Future], minDieValue: 6),

        new Card("Quantum Mining", "Resources +25",
            CardType.Boost, Rarity.Rare, TargetType.Self,
            [HistoricalPeriod.Future], minDieValue: 4),

        new Card("Neural Override", "Steal a card from enemy",
            CardType.Action, Rarity.Epic, TargetType.Enemy,
            [HistoricalPeriod.Future], minDieValue: 6),

        new Card("Space Blockade", "Enemy can't play Action cards this turn",
            CardType.Action, Rarity.Rare, TargetType.Enemy,
            [HistoricalPeriod.Future], minDieValue: 5),

        new Card("Singularity Glitch", "Reset all stats to 50",
            CardType.Event, Rarity.Epic, TargetType.AllPlayers,
            [HistoricalPeriod.Future], minDieValue: 6),
            
        // Boost cards
        new Card("Military Drill", "Boost your military by +10 for one turn.",
            CardType.Boost, Rarity.Common, TargetType.Self,
            [HistoricalPeriod.Ancient, HistoricalPeriod.Medieval, HistoricalPeriod.Modern], minDieValue: 2),

        new Card("Scientific Focus", "Boost your technology by +15 for one turn.",
            CardType.Boost, Rarity.Rare, TargetType.Self,
            [HistoricalPeriod.Modern, HistoricalPeriod.Future], minDieValue: 3),

        new Card("Resource Surge", "Gain extra resources this round.",
            CardType.Boost, Rarity.Common, TargetType.Self,
            [HistoricalPeriod.Ancient, HistoricalPeriod.Medieval, HistoricalPeriod.Modern, HistoricalPeriod.Future], minDieValue: 1),

        // Action cards
        new Card("Sabotage", "Reduce enemy's technology by 10.",
            CardType.Action, Rarity.Rare, TargetType.Enemy,
            [HistoricalPeriod.Modern, HistoricalPeriod.Future], minDieValue: 4),

        new Card("Espionage", "See all opponent cards.",
            CardType.Action, Rarity.Common, TargetType.Enemy,
            [HistoricalPeriod.Medieval, HistoricalPeriod.Modern, HistoricalPeriod.Future], minDieValue: 2),

        new Card("Supply Raid", "Steal resources from an opponent.",
            CardType.Action, Rarity.Common, TargetType.Enemy,
            [HistoricalPeriod.Ancient, HistoricalPeriod.Medieval], minDieValue: 3),

        // Event cards
        new Card("Famine", "All players lose 10 resources.",
            CardType.Event, Rarity.Common, TargetType.AllPlayers,
            [HistoricalPeriod.Ancient, HistoricalPeriod.Medieval], minDieValue: 1),

        new Card("Peace Treaty", "No attacks can occur this round.",
            CardType.Event, Rarity.Epic, TargetType.AllPlayers,
            [HistoricalPeriod.Medieval, HistoricalPeriod.Modern], minDieValue: 1),

        new Card("Scientific Breakthrough", "Random player gains +10 tech.",
            CardType.Event, Rarity.Rare, TargetType.Random,
            [HistoricalPeriod.Modern, HistoricalPeriod.Future], minDieValue: 5),
    };

    public Task<List<Card>> GetAll()
    {
        return Task.FromResult(_cards);
    }

    public Task<List<Card>> GetAvailableForPeriod(HistoricalPeriod period)
    {
        var filtered = _cards.Where(card => card.IsAvailableIn(period)).ToList();
        return Task.FromResult(filtered);
    }
}