namespace DominionProtocol.Domain.Model;

public static class GameSession
{
    public static Game Current { get; set; } = default!;
}
