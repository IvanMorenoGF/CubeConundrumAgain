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
            .Then(Somebody(Not(Alive))).Should().BeTrue();

        OnceUponATime()
            .Then(Somebody(Not(Alive)))
            .Should().BeFalse();
    }

    [Test]
    public void Somebody_IsDead_ButTheAreAlivePeople()
    {
        OnceUponATime()
            .Happened(Death().Of(Adam).WatchedBy(Eve))
            .Then(Somebody(Not(Alive))).Should().BeTrue();
    }

    [Test]
    public void METHOD()
    {
        OnceUponATime()
            .Happened(Solitude().Of(Adam))
            .Happened(Death().Of(Adam))
            .Then(Was(Alive(Adam))).Should().BeTrue();
        
        OnceUponATime()
            .Happened(Solitude().Of(Adam))
            .Happened(Death().Of(Adam))
            .Then(Was(Somebody(Alive))).Should().BeTrue();

        OnceUponATime()
            .Happened(Solitude().Of(Adam))
            .Happened(Death().Of(Adam))
            .Then(Somebody(Was(Alive))).Should().BeTrue();
    }

    [Test]
    public void Somebody_WorksWithNot_oAlgoAsí()
    {
        OnceUponATime()
            .Happened(Love().Between(Adam, Eve))
            .Then(Somebody(Not(Alive))).Should().BeFalse();
        
        OnceUponATime()
            .Happened(Love().Between(Adam, Eve))
            .Then(Somebody(Alive)).Should().BeTrue();
    }

    [Test]
    public void Somebody_IsDeadAndInLove()
    {
        OnceUponATime()
            .Happened(Solitude().Of(Adam))
            .Happened(Death().Of(Eve))
            .Then(Somebody(InTheCast,Alive)).Should().BeTrue();
       OnceUponATime()
            .Happened(Solitude().Of(Adam))
            .Happened(Death().Of(Adam))
            .Then(Somebody(InTheCast,Alive)).Should().BeFalse();
    }
}