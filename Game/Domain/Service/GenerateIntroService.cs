using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominionProtocol.Domain.Gateway;
using DominionProtocol.Domain.Model;

namespace DominionProtocol.Domain.Service;

public class GenerateIntroService
{
    private readonly IIntroGateway _gateway;

    public GenerateIntroService(IIntroGateway gateway)
    {
        _gateway = gateway;
    }

    public async Task<IntroNarrative> Generate(Nation player, List<Nation> opponents)
    {
        var prompt = BuildPrompt(player, opponents);
        return await _gateway.GenerateIntroText(prompt);
    }

    private string BuildPrompt(Nation player, List<Nation> opponents)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Player Nation: {player.Name}");
        sb.AppendLine("Opponents: " + string.Join(", ", opponents.Select(o => o.Name)));
        sb.AppendLine("Generate a game introduction in a narrative style.");

        return sb.ToString();
    }
}
