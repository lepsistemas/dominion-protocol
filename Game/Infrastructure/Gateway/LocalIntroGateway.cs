using System.Threading.Tasks;
using DominionProtocol.Domain.Gateway;
using DominionProtocol.Domain.Model;

namespace DominionProtocol.Infra.Gateway;

public class LocalIntroGateway : IIntroGateway
{
    public Task<IntroNarrative> GenerateIntroText(string prompt)
    {
        var text = """
        As a dominant force in your era, your nation holds unmatched strength in war and diplomacy.

        However, tensions rise as rivals stake their claims on nearby lands. Strategy will be your greatest weapon.

        The world watches as you prepare to take your first step toward conquest.
        """;
        return Task.FromResult(new IntroNarrative(text, true, "local"));
    }
}
