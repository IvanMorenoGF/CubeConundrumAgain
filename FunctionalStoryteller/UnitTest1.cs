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
    public void BuryAdan()
    {
        Death().Buried("Adan").IsInTheTomb("Adan").Should().BeTrue();

        OnceUponATime()
            .Happened(Death().Buried("Adan"))
            .IsAlive("Adan").Should().BeFalse();
    }

    [Test]
    public void FallInLove()
    {
        Love().Between("Adan", "Eva").AreCoupled("Adan", "Eva").Should().BeTrue();
        Love().Between("Adan", "Eva").AreCoupled("Eva", "Adan").Should().BeTrue();
        Love().Between("Adan", "Eva").AreCoupled("Eva", "Unrequited").Should().BeFalse();
        
        OnceUponATime()
            .Happened(Love().Between("Adan", "Eva"))
            .Loves("Adan", "Eva").Should().BeTrue();
    }

    [Test]
    public void FallInLove_NotInTheFirstTime()
    {
        OnceUponATime()
            .Happened(Death().Buried("Enriqueto"))
            .Happened(Love().Between("Adan", "Eva"))
            .Loves("Adan", "Eva").Should().BeTrue();
        
        OnceUponATime()
            .Happened(Love().Between("Enriqueto", "Segismundo"))
            .Happened(Love().Between("Adan", "Eva"))
            .Loves("Adan", "Eva").Should().BeTrue();
    }

    [Test, Ignore("todo")]
    public void asdfasd()
    {
        OnceUponATime()
            .Happened(Love().Between("Adan", "Eva"))
            .Happened(Love().Between("Adan", "Segismundo"))
            .Loves("Adan", "Segismundo").Should().BeFalse();
    }

    [Test]
    public void IsInTheCast()
    {
        Love().Between("Adan", "Eva").IsInTheCast("Adan").Should().BeTrue();
        Love().Between("Adan", "Eva").IsInTheCast("Eva").Should().BeTrue();
        Love().Between("Adan", "Eva").IsInTheCast("IsNot").Should().BeFalse();
    }

    [Test]
    public void WhomIsSomeoneInLoveWith()
    {
        OnceUponATime()
            .Happened(Love().Between("Adan", "Eva"))
            .WhomLoves("Adan")
            .Match(x => x.Should().Be("Eva"), Assert.Fail);
    }

    [Test]
    public void WhoLovesSomeone()
    {
        OnceUponATime()
            .Happened(Love().Between("Adan", "Eva"))
            .WhoLoves("Adan")
            .Match(x => x.Should().Be("Eva"), Assert.Fail);
        
        OnceUponATime()
            .Happened(Love().Between("Adan", "Eva"))
            .WhoLoves("Eva")
            .Match(x => x.Should().Be("Adan"), Assert.Fail);
    }

    [Test]
    public void Monogamy()
    {
        OnceUponATime()
            .Happened(Love().Between("Adan", "Eva"))
            .Happened(Love().Between("Adan", "Unrequited"))
            .WhoLoves("Unrequited").IsNone.Should().BeTrue();
    }

    [Test]
    public void ExternalPeople_IsNotInLoveStory()
    {
        OnceUponATime()
            .Happened(Love().Between("Adan", "Eva"))
            .WhoLoves("Other").IsNone.Should().BeTrue();
        
        OnceUponATime()
            .Happened(Love().Between("Adan", "Eva"))
            .WhomLoves("Other").IsNone.Should().BeTrue();
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
}