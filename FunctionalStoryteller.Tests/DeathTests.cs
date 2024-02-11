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
    
    [Test, Ignore("este es el test rojo por el que seguir")]
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
}