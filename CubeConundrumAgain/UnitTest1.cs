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
        Scene.Love().Between("Adan", "Eva").Loves("Adan", "Eva").Should().BeTrue();
        Scene.Love().Between("Adan", "Eva").Loves("Eva", "Adan").Should().BeTrue();
        Scene.Love().Between("Adan", "Eva").Loves("Eva", "dsfafsa").Should().BeFalse();
    }
}