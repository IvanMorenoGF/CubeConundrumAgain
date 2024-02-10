using FluentAssertions;
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
        Scene.Death().Buried("Adan").IsInTheTomb("Adan").Should().BeTrue();

        OnceUponATime()
            .Happened(Scene.Death().Buried("Adan"))
            .IsAlive("Adan").Should().BeFalse();
    }

    [Test]
    public void FallInLove()
    {
        Scene.Love().Between("Adan", "Eva").AreCoupled("Adan", "Eva").Should().BeTrue();
        Scene.Love().Between("Adan", "Eva").AreCoupled("Eva", "Adan").Should().BeTrue();
        Scene.Love().Between("Adan", "Eva").AreCoupled("Eva", "Unrequited").Should().BeFalse();
        
        OnceUponATime()
            .Happened(Scene.Love().Between("Adan", "Eva"))
            .Loves("Adan", "Eva").Should().BeTrue();
    }

    [Test]
    public void FallInLove_NotInTheFirstTime()
    {
        OnceUponATime()
            .Happened(Scene.Death().Buried("Enriqueto"))
            .Happened(Scene.Love().Between("Adan", "Eva"))
            .Loves("Adan", "Eva").Should().BeTrue();
        
        OnceUponATime()
            .Happened(Scene.Love().Between("Enriqueto", "Segismundo"))
            .Happened(Scene.Love().Between("Adan", "Eva"))
            .Loves("Adan", "Eva").Should().BeTrue();
    }

    [Test, Ignore("todo")]
    public void asdfasd()
    {
        OnceUponATime()
            .Happened(Scene.Love().Between("Adan", "Eva"))
            .Happened(Scene.Love().Between("Adan", "Segismundo"))
            .Loves("Adan", "Segismundo").Should().BeFalse();
    }

    [Test]
    public void IsInTheCast()
    {
        Scene.Love().Between("Adan", "Eva").IsInTheCast("Adan").Should().BeTrue();
        Scene.Love().Between("Adan", "Eva").IsInTheCast("Eva").Should().BeTrue();
        Scene.Love().Between("Adan", "Eva").IsInTheCast("IsNot").Should().BeFalse();
    }

    [Test]
    public void WhomIsSomeoneInLoveWith()
    {
        OnceUponATime()
            .Happened(Scene.Love().Between("Adan", "Eva"))
            .WhomLoves("Adan")
            .Match(x => x.Should().Be("Eva"), Assert.Fail);
    }

    [Test]
    public void WhoLovesSomeone()
    {
        OnceUponATime()
            .Happened(Scene.Love().Between("Adan", "Eva"))
            .WhoLoves("Adan")
            .Match(x => x.Should().Be("Eva"), Assert.Fail);
        
        OnceUponATime()
            .Happened(Scene.Love().Between("Adan", "Eva"))
            .WhoLoves("Eva")
            .Match(x => x.Should().Be("Adan"), Assert.Fail);
    }

    [Test]
    public void Monogamy()
    {
        OnceUponATime()
            .Happened(Scene.Love().Between("Adan", "Eva"))
            .Happened(Scene.Love().Between("Adan", "Unrequited"))
            .WhoLoves("Unrequited").IsNone.Should().BeTrue();
    }

    [Test]
    public void ExternalPeople_IsNotInLoveStory()
    {
        OnceUponATime()
            .Happened(Scene.Love().Between("Adan", "Eva"))
            .WhoLoves("Other").IsNone.Should().BeTrue();
        
        OnceUponATime()
            .Happened(Scene.Love().Between("Adan", "Eva"))
            .WhomLoves("Other").IsNone.Should().BeTrue();
    }

    [Test]
    public void OnlyUnrequitedIsHeartbroken()
    {
        OnceUponATime()
            .Happened(Scene.Love().Between("Adan", "Eva"))
            .Happened(Scene.Love().Between("Adan", "Unrequited"))
            .IsHeartbroken("Adan").Should().BeFalse();
        
        OnceUponATime()
            .Happened(Scene.Love().Between("Adan", "Eva"))
            .Happened(Scene.Love().Between("Adan", "Unrequited"))
            .IsHeartbroken("Eva").Should().BeFalse();
        
        OnceUponATime()
            .Happened(Scene.Love().Between("Adan", "Eva"))
            .Happened(Scene.Love().Between("Adan", "Unrequited"))
            .IsHeartbroken("Unrequited").Should().BeTrue();
    }

    [Test]
    public void CannotBeLoved_IfDead()
    {
        OnceUponATime()
            .Happened(Scene.Death().Buried("Adan"))
            .Happened(Scene.Love().Between("Adan", "Eva"))
            .WhoLoves("Adan").IsNone.Should().BeTrue();
        
        OnceUponATime()
            .Happened(Scene.Death().Buried("Adan"))
            .Happened(Scene.Love().Between("Adan", "Eva"))
            .WhoLoves("Eva").IsNone.Should().BeTrue();
    }
}