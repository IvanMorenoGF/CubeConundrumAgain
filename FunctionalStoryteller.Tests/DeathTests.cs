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
            .Happened(Death().Of(Adam)).Then(Alive(Adam)).Should().BeFalse();

        OnceUponATime()
            .Happened(Death().Of(Adam).WatchedBy(Eve)).Then(Alive(Eve)).Should().BeTrue();
    }
    
    [Test]
    public void CannotBeLoved_IfDead()
    {
        OnceUponATime()
            .Happened(Death().Of(Adam))
            .Happened(Love().Between(Adam, Eve))
            .WhoLoves(Adam).IsNone.Should().BeTrue();
        
        OnceUponATime()
            .Happened(Death().Of(Adam))
            .Happened(Love().Between(Adam, Eve))
            .WhoLoves(Eve).IsNone.Should().BeTrue();
    }

    [Test]
    public void TwoGhosts_FallInLove()
    {
        OnceUponATime()
            .Happened(Death().Of(Adam))
            .Happened(Death().Of(Eve))
            .Happened(Love().Between(Adam, Eve))
            .WhoLoves(Eve).IsNone.Should().BeFalse();
    }

    [Test]
    public void AreInSameAstralPlane()
    {
        OnceUponATime()
            .Happened(Death().Of(Adam).WatchedBy(Eve))
            .SharingAstralPlane(Adam, Eve).Should().BeFalse();
        
        OnceUponATime()
            .Happened(Death().Of(Adam))
            .Happened(Death().Of(Eve))
            .SharingAstralPlane(Adam, Eve).Should().BeTrue();
        
        OnceUponATime().SharingAstralPlane(Adam, Eve).Should().BeTrue();
    }

    [Test]
    public void KnowYouBecomeWidow_BreaksYourHeart()
    {
        OnceUponATime()
            .Happened(Love().Between(Adam, Eve))
            .Happened(Death().Of(Adam).WatchedBy(Eve))
            .Then(Heartbroken(Eve)).Should().BeTrue();
        
        OnceUponATime()
            .Happened(Love().Between(Adam, Eve))
            .Happened(Death().Of(Adam))
            .Then(Heartbroken(Eve)).Should().BeFalse(because: "she doesn't know");
        
        OnceUponATime()
            .Happened(Death().Of(Adam).WatchedBy(Eve))
            .Then(Heartbroken(Eve)).Should().BeFalse(because: "she wasn't in love");
    }

    [Test]
    public void CannotGrieve_Yourself()
    {
        Death().Of(Adam).PlaceAt(1, Adam).Should().Be(Death().Of(NobodyElse).WatchedBy(Adam));
    }
    
    [Test]
    public void ReviveSomeone()
    {
        OnceUponATime()
            .Happened(Death().Of(Adam))
            .Happened(Revive().Of(Adam))
            .Then(Alive(Adam)).Should().BeTrue();
    }
    
    [Test]
    public void ReviveSomeone_CanOnlyReviveDead()
    {
        OnceUponATime()
            .Happened(Revive().Of(Adam))
            .Happened(Death().Of(Adam))
            .Then(Alive(Adam)).Should().BeFalse();
    }

    [Test]
    public void Die_Revive_Die()
    {
        OnceUponATime()
            .Happened(Death().Of(Adam))
            .Happened(Revive().Of(Adam))
            .Happened(Death().Of(Adam))
            .Then(Alive(Adam)).Should().BeFalse();
    }

    [Test]
    public void IsNotInTheTomb()
    {
        Death().WatchedBy(Adam)
            .IsInTheTomb(Adam).Should().BeFalse();
    }
}