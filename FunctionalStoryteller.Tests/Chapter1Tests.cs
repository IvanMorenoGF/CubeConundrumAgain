using FluentAssertions;
using static FunctionalStoryteller.Scenes;
using static FunctionalStoryteller.Specs;
using static FunctionalStoryteller.Storyteller;
using static FunctionalStoryteller.Tests.CharactersToTestsWith;

namespace FunctionalStoryteller.Tests;

public class Chapter1Tests
{
    [Test]
    public void Level1()
    {
        OnceUponATime()
            .Happened(Solitude().Of(Adam))
            .Happened(Love().Between(Adam, Eva))
            .Happened(Death().Of(Adam))
            .Is(InLoveWith(Adam, Eva), Not(Alive(Adam)))
            .Should().BeTrue("se entiende que Adán muere feliz si Eva lo ama");
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