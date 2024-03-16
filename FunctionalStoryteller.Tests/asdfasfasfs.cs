using FluentAssertions;
using LanguageExt.UnsafeValueAccess;
using static FunctionalStoryteller.Scenes;
using static FunctionalStoryteller.Storyteller;
using static FunctionalStoryteller.Tests.CharactersToTestsWith;

namespace FunctionalStoryteller.Tests;

public class asdfasfasfs
{
    [Test]
    public void LaterScene_BetweenTwo_InAStory()
    {
        OnceUponATime()
            .Happened(Revive())
            .Happened(Death())
            .TheLater(Revive(),Death())
            .ValueUnsafe()
            .Should().Be(Death());
        
        OnceUponATime()
            .Happened(Death())
            .Happened(Revive())
            .TheLater(Revive(), Death())
            .ValueUnsafe()
            .Should().Be(Revive());
        
        OnceUponATime()
            .Happened(Death())
            .Happened(Revive())
            .TheLater(null, Death())
            .ValueUnsafe()
            .Should().Be(Death());
        
        OnceUponATime()
            .Happened(Death())
            .Happened(Revive())
            .TheLater(null, null)
            .ValueUnsafe()
            .Should().Be(null);
    }

    [Test]
    public void LaterScene_BetweenThree()
    {
        OnceUponATime()
            .Happened(Death())
            .Happened(Revive())
            .Happened(Death())
            .TheLater(Death(), Revive())
            .ValueUnsafe()
            .Should().Be(Death());
    }

    [Test]
    public void TheLatestDeath()
    {
        OnceUponATime()
            .Happened(Death().Of(Adam))
            .Happened(Revive())
            .TheLater<DeathScene>(wherein: x => x.IsInTheTomb(Adam))
            .IsSome.Should().BeTrue();
        
        OnceUponATime()
            .TheLater<DeathScene>(wherein: x => x.IsInTheTomb(Adam))
            .IsNone.Should().BeTrue();
    }

    [Test]
    public void AreInOrder()
    {
        OnceUponATime()
            .Happened(Death())
            .Happened(Revive())
            .AreInOrder(Death(), Revive())
            .Should().BeTrue();
        
        OnceUponATime()
            .Happened(Death())
            .Happened(Revive())
            .AreInOrder(Revive(), Death())
            .Should().BeFalse();
    }
}