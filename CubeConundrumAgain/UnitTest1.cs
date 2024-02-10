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
            .WhomIsInLoveWith("Adan").Should().Be("Eva");
    }

    [Test]
    public void WhoLovesSomeone()
    {
        Story.OnceUponATime()
            .Happened(Scene.Love().Between("Adan", "Eva"))
            .WhoLoves("Adan").Should().Be("Eva");
        
        Story.OnceUponATime()
            .Happened(Scene.Love().Between("Adan", "Eva"))
            .WhoLoves("Eva").Should().Be("Adan");
    }
    
    
}