using NetArchTest.Rules;

public class BoundariesTest
{
    [Fact]
    public void NothingButViewShouldReferenceGodot()
    {
        var result = Types
            .InCurrentDomain()
            .That()
            .DoNotResideInNamespace("DominionProtocol.Presentation.View")
            .And()
            .DoNotResideInNamespace("GodotPlugins")
            .ShouldNot()
            .HaveDependencyOn("Godot")
            .GetResult();

        AssertSuccess(result, "Classes outside of View referencing Godot");
    }

    [Fact]
    public void DomainShouldNotReferencePresentation()
    {
        var result = Types
            .InCurrentDomain()
            .That()
            .ResideInNamespace("DominionProtocol.Domain")
            .ShouldNot()
            .HaveDependencyOn("DominionProtocol.Presentation")
            .GetResult();

        AssertSuccess(result, "Domain layer should not depend on Presentation layer");
    }

    [Fact]
    public void DomainShouldNotReferenceInfrastructure()
    {
        var result = Types
            .InCurrentDomain()
            .That()
            .ResideInNamespace("DominionProtocol.Domain")
            .ShouldNot()
            .HaveDependencyOn("DominionProtocol.Infrastructure")
            .GetResult();

        AssertSuccess(result, "Domain layer should not depend on Infrastructure layer");
    }

    [Fact]
    public void UseCasesShouldNotDependOnView()
    {
        var result = Types
            .InCurrentDomain()
            .That()
            .ResideInNamespace("DominionProtocol.Domain.UseCase")
            .ShouldNot()
            .HaveDependencyOn("DominionProtocol.Presentation")
            .GetResult();

        AssertSuccess(result, "UseCases should not reference Views directly");
    }

    private static void AssertSuccess(TestResult result, string messageIfFails)
    {
        if (!result.IsSuccessful)
        {
            var details = string.Join("\n", result.FailingTypes.Select(t => t.FullName));
            Assert.True(false, $"{messageIfFails}:\n{details}");
        }
    }
}
