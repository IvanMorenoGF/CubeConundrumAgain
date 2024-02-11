using FluentAssertions;
using static FunctionalStoryteller.Scene;
using static FunctionalStoryteller.Spec;
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
            .Happened(Death().Of(Adam))
            .Satisfies(Dead(Adam), Loved(Adam)).Should().BeTrue();
    }

    [Test]
    public void Level2()
    {
        OnceUponATime()
            .Happened(Love().Between(Adam, Eva))
            .Happened(Death().Of(Adam).WatchedBy(Eva))
            .Happened(Death().Of(Eva))
            .Satisfies(Heartbroken(Eva)).Should().BeTrue();
    }

    [Test]
    public void Level3()
    {
        OnceUponATime()
            .Happened(Love().Between(Adam, Eva))
            .Happened(Death().Of(Adam).WatchedBy(Eva))
            .Happened(Love().Between(Adam, Eva))
            .Satisfies(Dead(Adam), Alive(Eva), Heartbroken(Eva)).Should().BeTrue();
    }
}