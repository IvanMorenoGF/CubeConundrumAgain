using FluentAssertions;
using static FunctionalStoryteller.Scene;
using static FunctionalStoryteller.Storyteller;

namespace FunctionalStoryteller.Tests;

public class DeathTests
{
    [Test]
    public void PeopleIsAlive()
    {
        OnceUponATime().IsAlive("Adan").Should().BeTrue();
        OnceUponATime().IsAlive("Eva").Should().BeTrue();
    }

    [Test]
    public void BuryAdan_DoesNotKillEva()
    {
        Death().Buried("Adan").IsInTheTomb("Adan").Should().BeTrue();

        OnceUponATime()
            .Happened(Death().Buried("Adan"))
            .IsAlive("Adan").Should().BeFalse();

        OnceUponATime()
            .Happened(Death().Buried("Adan").Grieving("Eva"))
            .IsAlive("Eva").Should().BeTrue();
    }
    
    [Test]
    public void CannotBeLoved_IfDead()
    {
        OnceUponATime()
            .Happened(Death().Buried("Adan"))
            .Happened(Love().Between("Adan", "Eva"))
            .WhoLoves("Adan").IsNone.Should().BeTrue();
        
        OnceUponATime()
            .Happened(Death().Buried("Adan"))
            .Happened(Love().Between("Adan", "Eva"))
            .WhoLoves("Eva").IsNone.Should().BeTrue();
    }

    [Test]
    public void TwoGhosts_FallInLove()
    {
        OnceUponATime()
            .Happened(Death().Buried("Adan"))
            .Happened(Death().Buried("Eva"))
            .Happened(Love().Between("Adan", "Eva"))
            .WhoLoves("Eva").IsNone.Should().BeFalse();
    }

    [Test]
    public void AreInSameAstralPlane()
    {
        OnceUponATime()
            .Happened(Death().Buried("Adan"))
            .SharingAstralPlane("Adan", "Eva").Should().BeFalse();
        
        OnceUponATime()
            .Happened(Death().Buried("Adan"))
            .Happened(Death().Buried("Eva"))
            .SharingAstralPlane("Adan", "Eva").Should().BeTrue();
        
        OnceUponATime().SharingAstralPlane("Adan", "Eva").Should().BeTrue();
    }
}