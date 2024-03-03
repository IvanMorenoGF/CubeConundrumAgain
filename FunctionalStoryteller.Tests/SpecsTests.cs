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
            .Happened(Solitude().Of(Eva))
            .Is(InTheCast(Adam)).Should().BeTrue();
        
        OnceUponATime().Is(InTheCast(Adam)).Should().BeFalse();
    }

    [Test]
    public void NegateASpec()
    {
        OnceUponATime().Is(Not(InTheCast(Adam)))
            .Should().NotBe(OnceUponATime().Is(InTheCast(Adam)));
    }

    [Test]
    public void IsAlive()
    {
        OnceUponATime()
            .Happened(Solitude().Of(Adam))
            .Is(Alive(Adam)).Should().BeTrue();
        
        OnceUponATime()
            .Happened(Death().Of(Adam))
            .Is(Alive(Adam)).Should().BeFalse();
    }

    [Test]
    public void CannotBeAlive_IfNotPresent_InCast()
    {
        OnceUponATime().Is(Alive(Adam)).Should().BeFalse();
    }

    [Test]
    public void FirstLoveOf()
    {
        OnceUponATime()
            .Happened(Love().Between(Adam, Eva))
            .Is(InLoveWith(Adam, Eva)).Should().BeTrue();
        
        OnceUponATime()
            .Happened(Love().Between(Adam, NobodyElse))
            .Is(InLoveWith(Adam, Eva)).Should().BeFalse();
    }

    [Test]
    public void IsKnowableOfLove()
    {
        OnceUponATime()
            .Happened(Love().Between(Adam, NobodyElse))
            .Is(KnowableOfLove(Adam)).Should().BeFalse();
        
        OnceUponATime()
            .Happened(Love().Between(Adam, Eva))
            .Is(KnowableOfLove(Adam)).Should().BeTrue();
        
        OnceUponATime()
            .Happened(Love().Between(Adam, Eva))
            .Happened(Death().Of(Adam))
            .Is(KnowableOfLove(Adam)).Should().BeTrue();
        
        OnceUponATime()
            .Happened(Love().Between(Adam, NobodyElse))
            .Happened(Love().Between(Adam, Eva))
            .Is(KnowableOfLove(Adam)).Should().BeTrue();
    }

    [Test]
    public void CannotMeetLoveWithGhost()
    {
        OnceUponATime()
            .Happened(Death().Of(Eva))
            .Happened(Love().Between(Adam, Eva))
            .Is(KnowableOfLove(Adam)).Should().BeFalse();
    }

    [Test]
    public void BeHeartbroken()
    {
        OnceUponATime()
            .Happened(Love().Between(Adam, Eva))
            .Happened(Death().Of(Adam).WatchedBy(Eva))
            .Is(Heartbroken(Eva)).Should().BeTrue();
    }

    [Test]
    public void Generate_Substories_UntilCertainPoint()
    {
        OnceUponATime()
            .Happened(Death().Of(Eva))
            .asfsafasf(until: 1).Should().HaveCount(1);
        
        OnceUponATime()
            .Happened(Death().Of(Eva))
            .Happened(Death().Of(Adam))
            .asfsafasf(until: 2).Should().HaveCount(2);

        OnceUponATime()
            .Happened(Solitude().Of(Adam))
            .Happened(Death().Of(Adam))
            .asfsafasf(until: 1).Single()
            .Is(Alive(Adam)).Should().BeTrue();
        
        OnceUponATime()
            .Happened(Solitude().Of(Adam))
            .Happened(Death().Of(Adam))
            .asfsafasf(until: 2)[0]
            .Is(Alive(Adam)).Should().BeTrue();
        
        OnceUponATime()
            .Happened(Solitude().Of(Adam))
            .Happened(Death().Of(Adam))
            .asfsafasf(until: 2)[1]
            .Is(Alive(Adam)).Should().BeFalse();
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
            .Happened(Death().Of(Eva))
            .Happened(Love().Between(Adam, Eva))
            .Happened(Death().WatchedBy(Adam))
            .asfsafasf()
            .Should().BeEquivalentTo
            (
                OnceUponATime()
                    .Happened(Death().Of(Adam))
                    .Happened(Death().Of(Eva))
                    .Happened(Love().Between(Adam, Eva))
                    .Happened(Death().WatchedBy(Adam))
                    .asfsafasf(4)
            );
    }
}