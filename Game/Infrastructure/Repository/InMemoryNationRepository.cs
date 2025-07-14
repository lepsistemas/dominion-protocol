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
        // --- Ancient ---
        new Nation("Rome", "Conquerors of Europe with unmatched legions.", "#D4AF37",
            new List<HistoricalPeriod> { HistoricalPeriod.Ancient },
            new NationAttributes(military: 90, technology: 60, resources: 70, diplomacy: 65)),

        new Nation("Babylon", "Masters of ancient science and stargazing.", "#9370DB",
            new List<HistoricalPeriod> { HistoricalPeriod.Ancient },
            new NationAttributes(military: 60, technology: 85, resources: 65, diplomacy: 75)),

        new Nation("Carthage", "Maritime traders and elephant-riding warriors.", "#DAA520",
            new List<HistoricalPeriod> { HistoricalPeriod.Ancient },
            new NationAttributes(military: 70, technology: 65, resources: 80, diplomacy: 60)),

        new Nation("Egypt", "Land of the Nile", "#FFD700",
            new List<HistoricalPeriod> { HistoricalPeriod.Ancient },
            new NationAttributes(military: 60, technology: 90, resources: 75, diplomacy: 70)),

        new Nation("Persia", "Empire of the East", "#8B0000",
            new List<HistoricalPeriod> { HistoricalPeriod.Ancient },
            new NationAttributes(military: 70, technology: 70, resources: 85, diplomacy: 60)),

        new Nation("Maya", "Astronomers and engineers of the jungle.", "#556B2F",
            [HistoricalPeriod.Ancient],
            new NationAttributes(military: 55, technology: 80, resources: 85, diplomacy: 75)),

        new Nation("Sparta", "Militaristic city-state with unmatched discipline.", "#B22222",
            [HistoricalPeriod.Ancient],
            new NationAttributes(military: 95, technology: 50, resources: 60, diplomacy: 30)),

        // --- Medieval ---
        new Nation("England", "Feudal kingdom with naval power", "#0057B7",
            new List<HistoricalPeriod> { HistoricalPeriod.Medieval },
            new NationAttributes(military: 75, technology: 65, resources: 60, diplomacy: 70)),

        new Nation("Mongols", "Nomadic empire of conquest", "#800000",
            new List<HistoricalPeriod> { HistoricalPeriod.Medieval },
            new NationAttributes(military: 95, technology: 50, resources: 70, diplomacy: 40)),

        new Nation("Byzantium", "The last light of Rome in the East.", "#6A5ACD",
            new List<HistoricalPeriod> { HistoricalPeriod.Medieval },
            new NationAttributes(military: 65, technology: 75, resources: 60, diplomacy: 80)),

        new Nation("Japan", "Feudal warriors driven by honor and tradition.", "#DC143C",
            new List<HistoricalPeriod> { HistoricalPeriod.Medieval },
            new NationAttributes(military: 85, technology: 60, resources: 70, diplomacy: 65)),

        new Nation("The Caliphate", "Golden Age of science and tolerance.", "#228B22",
            new List<HistoricalPeriod> { HistoricalPeriod.Medieval },
            new NationAttributes(military: 60, technology: 85, resources: 75, diplomacy: 80)),

        new Nation("Vikings", "Fearless raiders and seafarers.", "#A52A2A",
            [HistoricalPeriod.Medieval],
            new NationAttributes(military: 85, technology: 55, resources: 80, diplomacy: 45)),

        new Nation("Khmer Empire", "Temple-builders of Southeast Asia.", "#DA70D6",
            [HistoricalPeriod.Medieval],
            new NationAttributes(military: 60, technology: 75, resources: 85, diplomacy: 65)),

        new Nation("Holy Roman Empire", "A fragmented realm with imperial ambition.", "#4B0082",
            [HistoricalPeriod.Medieval],
            new NationAttributes(military: 70, technology: 70, resources: 65, diplomacy: 85)),

        // --- Modern ---
        new Nation("USA", "Technological and diplomatic global power.", "#3C3B6E",
            new List<HistoricalPeriod> { HistoricalPeriod.Modern },
            new NationAttributes(military: 90, technology: 95, resources: 85, diplomacy: 80)),

        new Nation("China", "Ancient wisdom meets industrial might.", "#DE2910",
            new List<HistoricalPeriod> { HistoricalPeriod.Modern },
            new NationAttributes(military: 80, technology: 85, resources: 90, diplomacy: 70)),

        new Nation("Germany", "Precision, power and scientific dominance.", "#000000",
            new List<HistoricalPeriod> { HistoricalPeriod.Modern },
            new NationAttributes(military: 85, technology: 90, resources: 75, diplomacy: 60)),

        new Nation("India", "Cultural mosaic and emerging giant.", "#FF9933",
            [HistoricalPeriod.Modern],
            new NationAttributes(military: 70, technology: 75, resources: 85, diplomacy: 85)),

        new Nation("France", "Diplomatic finesse meets innovation.", "#0055A4",
            [HistoricalPeriod.Modern],
            new NationAttributes(military: 80, technology: 85, resources: 80, diplomacy: 90)),

        new Nation("South Africa", "Strategic gateway between oceans and cultures.", "#006B3F",
            [HistoricalPeriod.Modern],
            new NationAttributes(military: 65, technology: 65, resources: 90, diplomacy: 70)),

        // --- Future ---
        new Nation("Orbital Syndicate", "Corporate space alliance driven by profit.", "#00FFFF",
            new List<HistoricalPeriod> { HistoricalPeriod.Future },
            new NationAttributes(military: 75, technology: 100, resources: 95, diplomacy: 45)),

        new Nation("AI Collective", "Hyperintelligent AI seeking calculated control.", "#808080",
            new List<HistoricalPeriod> { HistoricalPeriod.Future },
            new NationAttributes(military: 85, technology: 100, resources: 60, diplomacy: 40)),

        new Nation("Gaian Alliance", "Eco-symbiotic federation protecting life.", "#32CD32",
            new List<HistoricalPeriod> { HistoricalPeriod.Future },
            new NationAttributes(military: 60, technology: 90, resources: 75, diplomacy: 100)),

        new Nation("Neo-Genesis Union", "Post-human transcendents of flesh and code.", "#FF69B4",
            new List<HistoricalPeriod> { HistoricalPeriod.Future },
            new NationAttributes(military: 80, technology: 95, resources: 85, diplomacy: 90)),

        new Nation("Mars Republic", "Martian pioneers with scarce but potent resources.", "#FF4500",
            [HistoricalPeriod.Future],
            new NationAttributes(military: 70, technology: 95, resources: 65, diplomacy: 75)),

        new Nation("Quantum Dominion", "Rulers of space-time manipulation.", "#9400D3",
            [HistoricalPeriod.Future],
            new NationAttributes(military: 60, technology: 100, resources: 75, diplomacy: 85)),

        new Nation("Solar Cult", "Zealots of the sun wielding fusion power.", "#FFD700",
            [HistoricalPeriod.Future],
            new NationAttributes(military: 80, technology: 90, resources: 90, diplomacy: 50)),
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