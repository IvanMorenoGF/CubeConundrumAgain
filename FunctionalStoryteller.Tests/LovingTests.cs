using FluentAssertions;
using static FunctionalStoryteller.Storyteller;
using static FunctionalStoryteller.Tests.CharactersToTestsWith;

namespace FunctionalStoryteller.Tests;

public class LovingTests
{
    [Test]
    public void Nobody_LovesWithTheAir()
    {
        OnceUponATime()
            .Happened(Scenes.Love().Between("AloneOne", null))
            .FirstLoveOf("AloneOne")
            .IsNone.Should().BeTrue();
        
        OnceUponATime()
            .Happened(Scenes.Love().Between("AloneOne", null))
            .WhoLoves("AloneOne")
            .IsNone.Should().BeTrue();
    }
    [Test]
    public void WhomIsSomeoneInLoveWith()
    {
        OnceUponATime()
            .Happened(Scenes.Love().Between("Adan", "Eva"))
            .FirstLoveOf("Adan")
            .Match(x => x.Should().Be("Eva"), Assert.Fail);
    }

    [Test]
    public void WhoLovesSomeone()
    {
        OnceUponATime()
            .Happened(Scenes.Love().Between("Adan", "Eva"))
            .WhoLoves("Adan")
            .Match(x => x.Should().Be("Eva"), Assert.Fail);
        
        OnceUponATime()
            .Happened(Scenes.Love().Between("Adan", "Eva"))
            .WhoLoves("Eva")
            .Match(x => x.Should().Be("Adan"), Assert.Fail);
    }

    [Test]
    public void Monogamy()
    {
        OnceUponATime()
            .Happened(Scenes.Love().Between("Adan", "Eva"))
            .Happened(Scenes.Love().Between("Adan", "Rejected"))
            .WhoLoves("Rejected").IsNone.Should().BeTrue();
        
        OnceUponATime()
            .Happened(Scenes.Love().Between("Adan", "Eva"))
            .Happened(Scenes.Love().Between("Adan", "Segismundo"))
            .WhoLoves("Adan")
            .Match(x => x.Should().Be("Eva"), Assert.Fail);
    }

    [Test]
    public void ExternalPeople_IsNotInLoveStory()
    {
        OnceUponATime()
            .Happened(Scenes.Love().Between("Adan", "Eva"))
            .WhoLoves("Other").IsNone.Should().BeTrue();
        
        OnceUponATime()
            .Happened(Scenes.Love().Between("Adan", "Eva"))
            .FirstLoveOf("Other").IsNone.Should().BeTrue();
    }

    [Test]
    public void FallInLove_NotInTheFirstTime()
    {
        OnceUponATime()
            .Happened(Scenes.Death().Of("Enriqueto"))
            .Happened(Scenes.Love().Between("Adan", "Eva"))
            .WhoLoves("Adan")
            .Match(x => x.Should().Be("Eva"), Assert.Fail);
        
        OnceUponATime()
            .Happened(Scenes.Love().Between("Enriqueto", "Segismundo"))
            .Happened(Scenes.Love().Between("Adan", "Eva"))
            .WhoLoves("Eva")
            .Match(x => x.Should().Be("Adan"), Assert.Fail);
    }
    
    [Test]
    public void RejectSomeone()
    {
        OnceUponATime()
            .Happened(Scenes.Love().Between("Adan", "Eva"))
            .Happened(Scenes.Love().Between("Adan", "Rejected"))
            .WasRejected("Adan").Should().BeFalse();
        
        OnceUponATime()
            .Happened(Scenes.Love().Between("Adan", "Eva"))
            .Happened(Scenes.Love().Between("Adan", "Rejected"))
            .WasRejected("Eva").Should().BeFalse();
        
        OnceUponATime()
            .Happened(Scenes.Love().Between("Adan", "Eva"))
            .Happened(Scenes.Love().Between("Adan", "Rejected"))
            .WasRejected("Rejected").Should().BeTrue();
    }

    [Test]
    public void RejectSomeone_AnywaysFallsInLove()
    {
        OnceUponATime()
            .Happened(Scenes.Love().Between("Adan", "Eva"))
            .Happened(Scenes.Love().Between("Adan", "Rejected"))
            .FirstLoveOf("Rejected")
            .Match(x => x.Should().Be("Adan"), Assert.Fail);
        
        OnceUponATime()
            .Happened(Scenes.Love().Between("Adan", "Eva"))
            .Happened(Scenes.Love().Between("Adan", "Rejected"))
            .Happened(Scenes.Love().Between("Segismundo", "Rejected"))
            .WhoLoves("Rejected")
            .Match(x => x.Should().Be("Segismundo"), Assert.Fail);
    }

    [Test]
    public void CannotLove_Yourself()
    {
        Scenes.Love().Between(Adam, NobodyElse).PlaceAt(2, Adam).Should().Be(Scenes.Love().Between(NobodyElse, Adam));
    }
}