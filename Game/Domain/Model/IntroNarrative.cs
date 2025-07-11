namespace DominionProtocol.Domain.Model;

public class IntroNarrative
{
    public string Text { get; }
    public bool IsValid { get; }
    public string Source { get; }
    public string? ErrorMessage { get; }

    public IntroNarrative(string text, bool isValid = true, string source = "local", string? errorMessage = null)
    {
        Text = text;
        IsValid = isValid;
        Source = source;
        ErrorMessage = errorMessage;
    }
}
