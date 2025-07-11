using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DominionProtocol.Domain.Model;
using DominionProtocol.Domain.Repository;

namespace DominionProtocol.Infra.Repository;

public class InMemoryNationRepository : INationRepository
{
    private readonly List<Nation> _nations = new()
    {
        new Nation("Rome", "Ancient Roman Empire", 80, "#D4AF37",
            new List<HistoricalPeriod> { HistoricalPeriod.Ancient },
            new NationAttributes(military: 90, technology: 60, resources: 70, diplomacy: 65)
        ),
        new Nation("Egypt", "Land of the Nile", 70, "#FFD700",
            new List<HistoricalPeriod> { HistoricalPeriod.Ancient },
            new NationAttributes(military: 60, technology: 90, resources: 75, diplomacy: 70)
        ),
        new Nation("Persia", "Empire of the East", 75, "#8B0000",
            new List<HistoricalPeriod> { HistoricalPeriod.Ancient },
            new NationAttributes(military: 70, technology: 70, resources: 85, diplomacy: 60)
        ),

        new Nation("England", "Feudal kingdom with naval power", 60, "#0057B7",
            new List<HistoricalPeriod> { HistoricalPeriod.Medieval },
            new NationAttributes(military: 75, technology: 65, resources: 60, diplomacy: 70)
        ),
        new Nation("Mongols", "Nomadic empire of conquest", 90, "#800000",
            new List<HistoricalPeriod> { HistoricalPeriod.Medieval },
            new NationAttributes(military: 95, technology: 50, resources: 70, diplomacy: 40)
        ),
        new Nation("Byzantium", "Eastern Roman legacy", 70, "#6A5ACD",
            new List<HistoricalPeriod> { HistoricalPeriod.Medieval },
            new NationAttributes(military: 65, technology: 75, resources: 60, diplomacy: 80)
        ),

        new Nation("USA", "Modern superpower", 85, "#3C3B6E",
            new List<HistoricalPeriod> { HistoricalPeriod.Modern },
            new NationAttributes(military: 90, technology: 95, resources: 85, diplomacy: 80)
        ),
        new Nation("Russia", "Global military presence", 80, "#C8102E",
            new List<HistoricalPeriod> { HistoricalPeriod.Modern },
            new NationAttributes(military: 85, technology: 75, resources: 70, diplomacy: 60)
        ),
        new Nation("Brazil", "Rising economy with regional power", 70, "#009C3B",
            new List<HistoricalPeriod> { HistoricalPeriod.Modern },
            new NationAttributes(military: 65, technology: 60, resources: 80, diplomacy: 70)
        ),

        new Nation("Orbital Syndicate", "Spacefaring corporate alliance", 95, "#00FFFF",
            new List<HistoricalPeriod> { HistoricalPeriod.Future },
            new NationAttributes(military: 75, technology: 100, resources: 90, diplomacy: 50)
        ),
        new Nation("AI Collective", "Sentient artificial intelligence", 100, "#808080",
            new List<HistoricalPeriod> { HistoricalPeriod.Future },
            new NationAttributes(military: 85, technology: 100, resources: 60, diplomacy: 40)
        ),
        new Nation("Neo-Genesis Union", "Post-human federation of hybrid minds", 90, "#FF69B4",
            new List<HistoricalPeriod> { HistoricalPeriod.Future },
            new NationAttributes(military: 80, technology: 95, resources: 85, diplomacy: 90)
        )
    };

    public Task<List<Nation>> GetAll()
    {
        return Task.FromResult(_nations);
    }

    public Task<List<Nation>> GetAvailableForPeriod(HistoricalPeriod period)
    {
        var nations = _nations.Where(n => n.IsAvailableIn(period)).ToList();
        return Task.FromResult(nations);
    }
}
