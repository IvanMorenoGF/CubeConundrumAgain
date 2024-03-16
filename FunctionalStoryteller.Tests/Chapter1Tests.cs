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
            .Then(InLoveWith(Adam, Eva), Not(Alive(Adam)))
            .Should().BeTrue("se entiende que Adán muere feliz si Eva lo ama");
    }

    [Test]
    public void Level2()
    {
        OnceUponATime()
            .Happened(Love().Between(Adam, Eva))
            .Happened(Death().Of(Adam).WatchedBy(Eva))
            .Happened(Death().Of(Eva))
            .Then(Heartbroken(Eva), Not(Alive(Eva)))
            .Should().BeTrue("muere desconsolada por saber la muerte de Adán");
    }

    [Test]
    public void Level3()
    {
        OnceUponATime()
            .Happened(Love().Between(Adam, Eva))
            .Happened(Death().Of(Adam).WatchedBy(Eva))
            .Happened(Love().Between(Adam, Eva))
            .Then(InLoveWith(Eva, Adam), Scared(Eva))
            .Should().BeTrue("Eva está asustada por ver el fantasma de un amante");
    }

    [Test, Ignore("Tenemos que consolar a Eva y hacer que el was funcione")]
    public void Level4()
    {
        OnceUponATime()
            .Happened(Love().Between(Adam, Eva))
            .Happened(Death().Of(Adam).WatchedBy(Eva))
            .Happened(Revive().Of(Adam))
            .Happened(Love().Between(Adam, Eva))
            .Then(Was(Heartbroken(Eva)),Not(Heartbroken(Eva)))
            .Should().BeTrue("Eva se consuela al ver a su amante revivido");
    }
}