using System;
using System.Threading.Tasks;
using DominionProtocol.Domain.Model;

namespace DominionProtocol.Domain.UseCase;

public record PlayFullTurnInput(
    Game CurrentGame,
    Player HumanPlayer,
    Card SelectedCard,
    int DiceRoll,
    Func<Task> OnUpdateUI,
    Func<string, Task> OnCutscene,
    Func<string, Task> OnQuickMessage
);
