using NetArchTest.Rules;

public class BoundariesTest
{
    [Fact]
    public void OnlyViewLayerShouldReferenceGodot()
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

        if (!result.IsSuccessful)
        {
            var violatingTypes = string.Join("\n", result.FailingTypes.Select(t => t.FullName));
            var message = $"Found invalid references to Godot in non-View classes:\n{violatingTypes}";
            Assert.True(false, message);
        }
    }
}
