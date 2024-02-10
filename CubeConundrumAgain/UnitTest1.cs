using FluentAssertions;

namespace CubeConundrumAgain;

public class Tests
{
    [Test]
    public void OnceUponATime()
    {
        Story.OnceUponATime().IsAlive("Adan").Should().BeTrue();
        Story.OnceUponATime().IsAlive("Eva").Should().BeTrue();
    }

    [Test]
    public void BuryAdan()
    {
        Scene.Death().Buried("Adan").IsInTheTomb("Adan").Should().BeTrue();

        Story.OnceUponATime()
            .Happened(Scene.Death().Buried("Adan"))
            .IsAlive("Adan").Should().BeFalse();
    }

    [Test]
    public void fdsafsa()
    {
        Scene.Love().Between("Adan", "Eva").AreCoupled("Adan", "Eva").Should().BeTrue();
        Scene.Love().Between("Adan", "Eva").AreCoupled("Eva", "Adan").Should().BeTrue();
        Scene.Love().Between("Adan", "Eva").AreCoupled("Eva", "dsfafsa").Should().BeFalse();
        
        Story.OnceUponATime()
            .Happened(Scene.Love().Between("Adan", "Eva"))
            .Loves("Adan", "Eva").Should().BeTrue();
    }

    [Test]
    public void asfsafsa()
    {
        Story.OnceUponATime()
            .Happened(Scene.Love().Between("Adan", "Eva"))
            .Happened(Scene.Love().Between("Adan", "asfasfas"))
            .Loves("Adan", "asfasfas").Should().BeFalse();
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
        Story.OnceUponATime()
            .Happened(Scene.Love().Between("Adan", "Eva"))
            .WhomLoves("Adan")
            .Match(x => x.Should().Be("Eva"), Assert.Fail);
    }

    [Test]
    public void WhoLovesSomeone()
    {
        Story.OnceUponATime()
            .Happened(Scene.Love().Between("Adan", "Eva"))
            .WhoLoves("Adan")
            .Match(x => x.Should().Be("Eva"), Assert.Fail);
        
        Story.OnceUponATime()
            .Happened(Scene.Love().Between("Adan", "Eva"))
            .WhoLoves("Eva")
            .Match(x => x.Should().Be("Adan"), Assert.Fail);
    }

    [Test]
    public void Monogamy()
    {
        Story.OnceUponATime()
            .Happened(Scene.Love().Between("Adan", "Eva"))
            .Happened(Scene.Love().Between("Adan", "Unrequited"))
            .WhoLoves("Unrequited").IsNone.Should().BeTrue();
    }

    [Test]
    public void asfasf()
    {
        Story.OnceUponATime()
            .Happened(Scene.Love().Between("Adan", "Eva"))
            .WhoLoves("Other").IsNone.Should().BeTrue();
        
        Story.OnceUponATime()
            .Happened(Scene.Love().Between("Adan", "Eva"))
            .WhomLoves("Other").IsNone.Should().BeTrue();
    }

    [Test]
    public void OnlyUnrequitedIsHeartbroken()
    {
        Story.OnceUponATime()
            .Happened(Scene.Love().Between("Adan", "Eva"))
            .Happened(Scene.Love().Between("Adan", "Unrequited"))
            .IsHeartbroken("Adan").Should().BeFalse();
        
        Story.OnceUponATime()
            .Happened(Scene.Love().Between("Adan", "Eva"))
            .Happened(Scene.Love().Between("Adan", "Unrequited"))
            .IsHeartbroken("Eva").Should().BeFalse();
        
        Story.OnceUponATime()
            .Happened(Scene.Love().Between("Adan", "Eva"))
            .Happened(Scene.Love().Between("Adan", "Unrequited"))
            .IsHeartbroken("Unrequited").Should().BeTrue();
    }
}