using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DominionProtocol.Domain.Model;
using DominionProtocol.Domain.Repository;

namespace DominionProtocol.Infra.Repository;

public class InMemoryCardRepository : ICardRepository
{
    private readonly List<Card> _cards = new()
    {
        // Boost cards
        new Card("Military Drill", "Boost your military by +10 for one turn.", CardType.Boost),
        new Card("Scientific Focus", "Boost your technology by +15 for one turn.", CardType.Boost),
        new Card("Resource Surge", "Gain extra resources this round.", CardType.Boost),

        // Action cards
        new Card("Sabotage", "Reduce enemy's technology by 10.", CardType.Action),
        new Card("Espionage", "See all opponent cards.", CardType.Action),
        new Card("Supply Raid", "Steal resources from an opponent.", CardType.Action),

        // Event cards
        new Card("Famine", "All players lose 10 resources.", CardType.Event),
        new Card("Peace Treaty", "No attacks can occur this round.", CardType.Event),
        new Card("Scientific Breakthrough", "Random player gains +10 tech.", CardType.Event),
    };

    public Task<List<Card>> GetAll()
    {
        return Task.FromResult(_cards);
    }

    public Task<List<Card>> GetAvailableForPeriod(HistoricalPeriod period)
    {
        return Task.FromResult(_cards);
    }
}
