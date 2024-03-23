using FluentAssertions;
using static FunctionalStoryteller.Scenes;
using static FunctionalStoryteller.Specs;
using static FunctionalStoryteller.Storyteller;
using static FunctionalStoryteller.Tests.CharactersToTestsWith;

namespace FunctionalStoryteller.Tests;

public class SomebodyTests
{
    [Test]
    public void Somebody_IsDead()
    {
        OnceUponATime()
            .Happened(Death().Of(Adam))
            .Then(Not(Somebody(Alive))).Should().BeTrue();

        OnceUponATime()
            .Then(Not(Somebody(Alive)))
            .Should().BeFalse();
    }

    [Test]
    public void Somebody_IsDead_ButTheAreAlivePeople()
    {
        OnceUponATime()
            .Happened(Death().Of(Adam).WatchedBy(Eve))
            .Then(Not(Somebody(Alive))).Should().BeTrue();
    }

    [Test]
    public void Somebody_WorksWithNot_oAlgoAsí()
    {
        OnceUponATime()
            .Happened(Love().Between(Adam, Eve))
            .Then(Not(Somebody(Alive))).Should().BeFalse();
        
        OnceUponATime()
            .Happened(Love().Between(Adam, Eve))
            .Then(Somebody(Alive)).Should().BeTrue();

    }
}