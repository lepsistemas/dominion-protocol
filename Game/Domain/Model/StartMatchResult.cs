using System.Collections.Generic;

namespace DominionProtocol.Domain.Model;

public class StartMatchResult
{
    public Game Game { get; }
    public string PeriodName { get; }
    public Nation PlayerNation { get; }
    public List<Nation> Opponents { get; }
    public string ContextNarrative { get; }

    public StartMatchResult(Game game, string periodName, Nation playerNation, List<Nation> opponents, string contextNarrative)
    {
        Game = game;
        PeriodName = periodName;
        PlayerNation = playerNation;
        Opponents = opponents;
        ContextNarrative = contextNarrative;
    }
}
