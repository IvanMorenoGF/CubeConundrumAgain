using FluentAssertions;
using static FunctionalStoryteller.Scenes;
using static FunctionalStoryteller.Specs;
using static FunctionalStoryteller.Storyteller;
using static FunctionalStoryteller.Tests.CharactersToTestsWith;

namespace FunctionalStoryteller.Tests;

public class DeathTests
{
    [Test]
    public void BuryAdan_DoesNotKillEva()
    {
        Death().Of(Adam).IsInTheTomb(Adam).Should().BeTrue();

        OnceUponATime()
            .Happened(Death().Of(Adam)).Is(Specs.Alive(Adam)).Should().BeFalse();

        OnceUponATime()
            .Happened(Death().Of(Adam).WatchedBy(Eva)).Is(Specs.Alive(Eva)).Should().BeTrue();
    }
    
    [Test]
    public void CannotBeLoved_IfDead()
    {
        OnceUponATime()
            .Happened(Death().Of(Adam))
            .Happened(Love().Between(Adam, Eva))
            .WhoLoves(Adam).IsNone.Should().BeTrue();
        
        OnceUponATime()
            .Happened(Death().Of(Adam))
            .Happened(Love().Between(Adam, Eva))
            .WhoLoves(Eva).IsNone.Should().BeTrue();
    }

    [Test]
    public void TwoGhosts_FallInLove()
    {
        OnceUponATime()
            .Happened(Death().Of(Adam))
            .Happened(Death().Of(Eva))
            .Happened(Love().Between(Adam, Eva))
            .WhoLoves(Eva).IsNone.Should().BeFalse();
    }

    [Test]
    public void AreInSameAstralPlane()
    {
        OnceUponATime()
            .Happened(Death().Of(Adam).WatchedBy(Eva))
            .SharingAstralPlane(Adam, Eva).Should().BeFalse();
        
        OnceUponATime()
            .Happened(Death().Of(Adam))
            .Happened(Death().Of(Eva))
            .SharingAstralPlane(Adam, Eva).Should().BeTrue();
        
        OnceUponATime().SharingAstralPlane(Adam, Eva).Should().BeTrue();
    }

    [Test]
    public void KnowYouBecomeWidow_BreaksYourHeart()
    {
        OnceUponATime()
            .Happened(Love().Between(Adam, Eva))
            .Happened(Death().Of(Adam).WatchedBy(Eva))
            .IsHeartbroken(Eva).Should().BeTrue();
        
        OnceUponATime()
            .Happened(Death().Of(Adam).WatchedBy(Eva))
            .IsHeartbroken(Eva).Should().BeFalse(because: "she wasn't in love");
        
        OnceUponATime()
            .Happened(Love().Between(Adam, Eva))
            .Happened(Death().Of(Adam))
            .IsHeartbroken(Eva).Should().BeFalse(because: "she doesn't know");
    }

    [Test]
    public void CannotGrieve_Yourself()
    {
        Death().Of(Adam).PlaceAt(1, Adam).Should().Be(Death().Of(NobodyElse).WatchedBy(Adam));
    }
}

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
            .Happened(Death().Of(Adam))
            .Is(KnowableOfLove(Adam)).Should().BeTrue();
    }
}