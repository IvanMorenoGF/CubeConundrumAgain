using FluentAssertions;
using static FunctionalStoryteller.Scene;
using static FunctionalStoryteller.Storyteller;
using static FunctionalStoryteller.Tests.CharactersToTestsWith;

namespace FunctionalStoryteller.Tests;

public class Chapter1Tests
{
    [Test]
    public void Level1()
    {
        OnceUponATime()
            .Happened(Love().Between(Adam, NobodyElse))
            .Happened(Love().Between(Adam, Eva))
            .Happened(Death().Buried(Adam))
            .WhoLoves(Adam).IsSome.Should().BeTrue("se entiende que Adán muere feliz si Eva lo ama");
    }

    [Test]
    public void Level2()
    {
        OnceUponATime()
            .Happened(Love().Between(Adam, Eva))
            .Happened(Death().Buried(Adam).Grieving(Eva))
            .Happened(Death().Buried(Eva))
            .IsHeartbroken(Eva).Should().BeTrue("muere desconsolada por saber la muerte de Adán");
    }
}