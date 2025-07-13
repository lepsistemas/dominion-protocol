namespace DominionProtocol.Infra.Repository;

public static class RepositoryLocator
{
    public static readonly InMemoryGameSettingsRepository GameSettings = new();
    public static readonly InMemoryNationRepository Nations = new();
    public static readonly InMemoryCardRepository Cards = new();
}
