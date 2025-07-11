using System.Threading.Tasks;
using DominionProtocol.Domain.Model;

namespace DominionProtocol.Domain.Gateway;

public interface IIntroGateway
{
    Task<IntroNarrative> GenerateIntroText(string prompt);
}
