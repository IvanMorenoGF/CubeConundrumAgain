using FluentAssertions;
using static CubeConundrumAgain.Scene;
using static CubeConundrumAgain.Storyteller;

namespace CubeConundrumAgain;

public class LovingTests
{
    [Test]
    public void Nobody_LovesWithTheAir()
    {
        OnceUponATime()
            .Happened(Love().With("AloneOne"))
            .WhomLoves("AloneOne")
            .IsNone.Should().BeTrue();
        
        OnceUponATime()
            .Happened(Love().With("AloneOne"))
            .WhoLoves("AloneOne")
            .IsNone.Should().BeTrue();
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
        
        OnceUponATime()
            .Happened(Love().Between("Adan", "Eva"))
            .Happened(Love().Between("Adan", "Segismundo"))
            .WhoLoves("Adan")
            .Match(x => x.Should().Be("Eva"), Assert.Fail);
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
    public void FallInLove_NotInTheFirstTime()
    {
        OnceUponATime()
            .Happened(Death().Buried("Enriqueto"))
            .Happened(Love().Between("Adan", "Eva"))
            .WhoLoves("Adan")
            .Match(x => x.Should().Be("Eva"), Assert.Fail);
        
        OnceUponATime()
            .Happened(Love().Between("Enriqueto", "Segismundo"))
            .Happened(Love().Between("Adan", "Eva"))
            .WhoLoves("Eva")
            .Match(x => x.Should().Be("Adan"), Assert.Fail);
    }
}