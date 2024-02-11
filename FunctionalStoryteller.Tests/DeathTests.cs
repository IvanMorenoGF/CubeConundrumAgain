using FluentAssertions;
using static FunctionalStoryteller.Scene;
using static FunctionalStoryteller.Storyteller;
using static FunctionalStoryteller.Tests.CharactersToTestsWith;

namespace FunctionalStoryteller.Tests;

public class DeathTests
{
    [Test]
    public void PeopleIsAlive()
    {
        OnceUponATime().IsAlive(Adam).Should().BeTrue();
        OnceUponATime().IsAlive(Eva).Should().BeTrue();
    }

    [Test]
    public void BuryAdan_DoesNotKillEva()
    {
        Death().Buried(Adam).IsInTheTomb(Adam).Should().BeTrue();

        OnceUponATime()
            .Happened(Death().Buried(Adam))
            .IsAlive(Adam).Should().BeFalse();

        OnceUponATime()
            .Happened(Death().Buried(Adam).Grieving(Eva))
            .IsAlive(Eva).Should().BeTrue();
    }
    
    [Test]
    public void CannotBeLoved_IfDead()
    {
        OnceUponATime()
            .Happened(Death().Buried(Adam))
            .Happened(Love().Between(Adam, Eva))
            .WhoLoves(Adam).IsNone.Should().BeTrue();
        
        OnceUponATime()
            .Happened(Death().Buried(Adam))
            .Happened(Love().Between(Adam, Eva))
            .WhoLoves(Eva).IsNone.Should().BeTrue();
    }

    [Test]
    public void TwoGhosts_FallInLove()
    {
        OnceUponATime()
            .Happened(Death().Buried(Adam))
            .Happened(Death().Buried(Eva))
            .Happened(Love().Between(Adam, Eva))
            .WhoLoves(Eva).IsNone.Should().BeFalse();
    }

    [Test]
    public void AreInSameAstralPlane()
    {
        OnceUponATime()
            .Happened(Death().Buried(Adam))
            .SharingAstralPlane(Adam, Eva).Should().BeFalse();
        
        OnceUponATime()
            .Happened(Death().Buried(Adam))
            .Happened(Death().Buried(Eva))
            .SharingAstralPlane(Adam, Eva).Should().BeTrue();
        
        OnceUponATime().SharingAstralPlane(Adam, Eva).Should().BeTrue();
    }

    [Test]
    public void KnowYouBecomeWidow_BreaksYourHeart()
    {
        OnceUponATime()
            .Happened(Love().Between(Adam, Eva))
            .Happened(Death().Buried(Adam).Grieving(Eva))
            .IsHeartbroken(Eva).Should().BeTrue();
        
        OnceUponATime()
            .Happened(Death().Buried(Adam).Grieving(Eva))
            .IsHeartbroken(Eva).Should().BeFalse(because: "she wasn't in love");
        
        OnceUponATime()
            .Happened(Love().Between(Adam, Eva))
            .Happened(Death().Buried(Adam))
            .IsHeartbroken(Eva).Should().BeFalse(because: "she doesn't know");
    }
}