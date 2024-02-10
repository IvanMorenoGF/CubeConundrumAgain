using FluentAssertions;
using static CubeConundrumAgain.Scene;
using static CubeConundrumAgain.Storyteller;

namespace CubeConundrumAgain;

public class Tests
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
    public void IsInTheCast()
    {
        Love().Between("Adan", "Eva").IsInTheCast("Adan").Should().BeTrue();
        Love().Between("Adan", "Eva").IsInTheCast("Eva").Should().BeTrue();
        Love().Between("Adan", "Eva").IsInTheCast("IsNot").Should().BeFalse();
    }

    [Test]
    public void OnlyUnrequitedIsHeartbroken()
    {
        OnceUponATime()
            .Happened(Love().Between("Adan", "Eva"))
            .Happened(Love().Between("Adan", "Unrequited"))
            .IsHeartbroken("Adan").Should().BeFalse();
        
        OnceUponATime()
            .Happened(Love().Between("Adan", "Eva"))
            .Happened(Love().Between("Adan", "Unrequited"))
            .IsHeartbroken("Eva").Should().BeFalse();
        
        OnceUponATime()
            .Happened(Love().Between("Adan", "Eva"))
            .Happened(Love().Between("Adan", "Unrequited"))
            .IsHeartbroken("Unrequited").Should().BeTrue();
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