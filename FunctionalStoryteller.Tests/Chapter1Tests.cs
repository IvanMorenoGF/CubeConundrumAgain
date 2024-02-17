using FluentAssertions;
using static FunctionalStoryteller.Scene;
using static FunctionalStoryteller.Storyteller;
using static FunctionalStoryteller.Tests.CharactersToTestsWith;

namespace FunctionalStoryteller.Tests;

public class Chapter1Tests
{
    [Test, Ignore("todo")]
    public void Level1()
    {
        OnceUponATime()
            .Happened(Solitude().Of(Adam))
            .Happened(Love().Between(Adam, Eva))
            .Happened(Death().Of(Adam))
            .WhoLoves(Adam).IsSome.Should().BeTrue("se entiende que Adán muere feliz si Eva lo ama");
    }

    [Test]
    public void Level2()
    {
        OnceUponATime()
            .Happened(Love().Between(Adam, Eva))
            .Happened(Death().Of(Adam).WatchedBy(Eva))
            .Happened(Death().Of(Eva))
            .IsHeartbroken(Eva).Should().BeTrue("muere desconsolada por saber la muerte de Adán");
    }

    [Test]
    public void Level3()
    {
        OnceUponATime()
            .Happened(Love().Between(Adam, Eva))
            .Happened(Death().Of(Adam).WatchedBy(Eva))
            .Happened(Love().Between(Adam, Eva))
            .SharingAstralPlane(Adam, Eva).Should().BeFalse("falta decir que está asustada...");
    }
}