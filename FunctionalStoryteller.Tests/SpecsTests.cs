using FluentAssertions;
using static FunctionalStoryteller.Scenes;
using static FunctionalStoryteller.Specs;
using static FunctionalStoryteller.Storyteller;
using static FunctionalStoryteller.Tests.CharactersToTestsWith;

namespace FunctionalStoryteller.Tests;

public class SpecsTests
{
    [Test]
    public void IsInTheCast()
    {
        OnceUponATime()
            .Happened(Solitude().Of(Adam))
            .Happened(Solitude().Of(Eve))
            .Then(InTheCast(Adam)).Should().BeTrue();

        OnceUponATime().Then(InTheCast(Adam)).Should().BeFalse();
    }

    [Test]
    public void NegateASpec()
    {
        OnceUponATime().Then(Not(InTheCast(Adam)))
            .Should().NotBe(OnceUponATime().Then(InTheCast(Adam)));
    }

    [Test]
    public void IsAlive()
    {
        OnceUponATime()
            .Happened(Solitude().Of(Adam))
            .Then(Alive(Adam)).Should().BeTrue();

        OnceUponATime()
            .Happened(Death().Of(Adam))
            .Then(Alive(Adam)).Should().BeFalse();
    }

    [Test]
    public void CannotBeAlive_IfNotPresent_InCast()
    {
        OnceUponATime().Then(Alive(Adam)).Should().BeFalse();
    }

    [Test]
    public void BecameScared()
    {
        OnceUponATime()
            .Happened(Death().Of(Adam))
            .Happened(Love().Between(Adam, Eve))
            .Then(Scared(Eve)).Should().BeTrue();

        OnceUponATime()
            .Happened(Death().Of(Adam))
            .Then(Scared(Eve)).Should().BeFalse();
    }

    [Test, Ignore("Necesitamos temporalidad para esta spec")]
    public void DidNot_BecameScared_IfSharedCast_WithCharacterAboutToDie()
    {
        OnceUponATime()
            .Happened(Love().Between(Adam, Eve))
            .Happened(Death().Of(Adam))
            .Then(Scared(Eve)).Should().BeFalse();
    }

    [Test]
    public void CutStory_UntilCertainScene()
    {
        OnceUponATime()
            .Happened(Solitude().Of(Adam))
            .CutUntil(Solitude().Of(Adam))
            .Should().Be
            (
                OnceUponATime().Happened(Solitude().Of(Adam))
            );
        
        OnceUponATime()
            .Happened(Solitude().Of(Adam))
            .Happened(Death().Of(Adam))
            .Happened(Love().Between(Adam, Eve))
            .CutUntil(Death().Of(Adam))
            .Should().Be
            (
                OnceUponATime().Happened(Solitude().Of(Adam)).Happened(Death().Of(Adam))
            );
    }

    [Test]
    public void FirstLoveOf()
    {
        OnceUponATime()
            .Happened(Love().Between(Adam, Eve))
            .Then(InLoveWith(Adam, Eve)).Should().BeTrue();

        OnceUponATime()
            .Happened(Love().Between(Adam, NobodyElse))
            .Then(InLoveWith(Adam, Eve)).Should().BeFalse();
    }

    [Test]
    public void IsKnowableOfLove()
    {
        OnceUponATime()
            .Happened(Love().Between(Adam, NobodyElse))
            .Then(KnowableOfLove(Adam)).Should().BeFalse();

        OnceUponATime()
            .Happened(Love().Between(Adam, Eve))
            .Then(KnowableOfLove(Adam)).Should().BeTrue();

        OnceUponATime()
            .Happened(Love().Between(Adam, Eve))
            .Happened(Death().Of(Adam))
            .Then(KnowableOfLove(Adam)).Should().BeTrue();

        OnceUponATime()
            .Happened(Love().Between(Adam, NobodyElse))
            .Happened(Love().Between(Adam, Eve))
            .Then(KnowableOfLove(Adam)).Should().BeTrue();
    }

    [Test]
    public void CannotMeetLoveWithGhost()
    {
        OnceUponATime()
            .Happened(Death().Of(Eve))
            .Happened(Love().Between(Adam, Eve))
            .Then(KnowableOfLove(Adam)).Should().BeFalse();
    }

    [Test]
    public void BeHeartbroken()
    {
        OnceUponATime()
            .Happened(Love().Between(Adam, Eve))
            .Happened(Death().Of(Adam).WatchedBy(Eve))
            .Then(Heartbroken(Eve)).Should().BeTrue();

        OnceUponATime()
            .Happened(Love().Between(Adam, Eve))
            .Then(Heartbroken(Eve)).Should().BeFalse();

        OnceUponATime()
            .Happened(Love().Between(Adam, Eve))
            .Happened(Death().Of(Adam))
            .Then(Heartbroken(Eve)).Should().BeFalse();
    }

    [Test, Ignore("Necesitamos comprobar el plano astral en esta spec")]
    public void CannotBeHeartbroken_IfLoverDiedBeforeLove()
    {
        OnceUponATime()
            .Happened(Death().Of(Adam).WatchedBy(Eve))
            .Happened(Love().Between(Adam, Eve))
            .Then(Heartbroken(Eve)).Should().BeFalse();
    }

    [Test, Ignore("Sólo comprobamos la primera historia de amor")]
    public void FallInLoveAgain()
    {
        OnceUponATime()
            .Happened(Love().Between(Adam, Eve))
            .Happened(Death().Of(Adam).WatchedBy(Eve))
            .Happened(Love().Between(AnybodyElse, Eve))
            .Then(Heartbroken(Eve)).Should().BeFalse();
    }

    [Test]
    public void Generate_Substories_UntilCertainPoint()
    {
        OnceUponATime()
            .Happened(Death().Of(Eve))
            .asfsafasf(until: 1).Should().HaveCount(1);

        OnceUponATime()
            .Happened(Death().Of(Eve))
            .asfsafasf(until: 1).Single()
            .Should().Be
            (
                OnceUponATime().Happened(Death().Of(Eve))
            );

        OnceUponATime()
            .Happened(Death().Of(Eve))
            .Happened(Death().Of(Adam))
            .asfsafasf(until: 2).Should().HaveCount(2);

        OnceUponATime()
            .Happened(Solitude().Of(Adam))
            .Happened(Death().Of(Adam))
            .asfsafasf(until: 1).Single()
            .Then(Alive(Adam)).Should().BeTrue();

        OnceUponATime()
            .Happened(Solitude().Of(Adam))
            .Happened(Death().Of(Adam))
            .asfsafasf(until: 2)[0]
            .Then(Alive(Adam)).Should().BeTrue();

        OnceUponATime()
            .Happened(Solitude().Of(Adam))
            .Happened(Death().Of(Adam))
            .asfsafasf(until: 2)[1]
            .Then(Alive(Adam)).Should().BeFalse();
    }

    [Test]
    public void GenerateAllSubStories()
    {
        OnceUponATime()
            .Happened(Death().Of(Adam))
            .asfsafasf()
            .Should().HaveCount(1);

        OnceUponATime()
            .Happened(Death().Of(Adam))
            .Happened(Death().Of(Eve))
            .Happened(Love().Between(Adam, Eve))
            .Happened(Death().WatchedBy(Adam))
            .asfsafasf()
            .Should().BeEquivalentTo
            (
                OnceUponATime()
                    .Happened(Death().Of(Adam))
                    .Happened(Death().Of(Eve))
                    .Happened(Love().Between(Adam, Eve))
                    .Happened(Death().WatchedBy(Adam))
                    .asfsafasf(4)
            );
    }

    [Test]
    public void Was_ASpecSatisfied()
    {
        OnceUponATime()
            .Happened(Death().Of(Adam))
            .Then(Was(Alive(Adam)))
            .Should().BeFalse();

        OnceUponATime()
            .Happened(Death().Of(Adam))
            .Happened(Death().Of(Eve))
            .Then(Was(Alive(Adam)))
            .Should().BeFalse();

        OnceUponATime()
            .Happened(Death().WatchedBy(Adam))
            .Happened(Death().Of(Adam))
            .Then(Was(Alive(Adam)))
            .Should().BeTrue();

        OnceUponATime()
            .Happened(Death().WatchedBy(Adam))
            .Happened(Death().Of(Adam))
            .Happened(Death().Of(Adam))
            .Then(Was(Alive(Adam)))
            .Should().BeTrue();
    }
}