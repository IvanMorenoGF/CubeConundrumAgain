using FluentAssertions;
using static FunctionalStoryteller.Scene;
using static FunctionalStoryteller.Storyteller;

namespace FunctionalStoryteller.Tests;

public class MiscTests
{
    [Test]
    public void IsInTheCast()
    {
        Love().Between("Adan", "Eva").IsInTheCast("Adan").Should().BeTrue();
        Love().Between("Adan", "Eva").IsInTheCast("Eva").Should().BeTrue();
        Love().Between("Adan", "Eva").IsInTheCast("IsNot").Should().BeFalse();
    }

    [Test]
    public void TellScene_AtVignette()
    {
        StoryBoard.Blank(1).Tell().Should().BeEquivalentTo(OnceUponATime());
    }

    [Test]
    public void CreateAStory()
    {
        StoryBoard.Blank(1).lkajsdlfkj(1, Death()).Tell().Should().NotBeEquivalentTo(OnceUponATime());
        StoryBoard.Blank(1).lkajsdlfkj(1, Death()).Tell().Should().BeEquivalentTo(OnceUponATime().Happened(Death()));
    }

    [Test]
    public void Compose_TwoScenes()
    {
        StoryBoard.Blank(2)
            .lkajsdlfkj(1, Death())
            .lkajsdlfkj(2, Death().Of("Adan"))
            .Tell()
            .Should().BeEquivalentTo(OnceUponATime().Happened(Death()).Happened(Death().Of("Adan")));
    }

    [Test]
    public void SwapScenes()
    {
        StoryBoard.Blank(2)
            .lkajsdlfkj(1, Death())
            .lkajsdlfkj(2, Death().Of("Adan"))
            .Swap(1, 2)
            .Tell()
            .Should().BeEquivalentTo(OnceUponATime().Happened(Death().Of("Adan")).Happened(Death()));
    }

    [Test]
    public void TellStoryUntil()
    {
        StoryBoard.Blank(2)
            .lkajsdlfkj(1, Love())
            .lkajsdlfkj(2, Death())
            .TellUntil(1)
            .Should().BeEquivalentTo(OnceUponATime().Happened(Love()));
        
        StoryBoard.Blank(20)
            .lkajsdlfkj(1, Love())
            .lkajsdlfkj(6, Death())
            .lkajsdlfkj(17, Death().Of("Adan"))
            .TellUntil(11)
            .Should().BeEquivalentTo(OnceUponATime().Happened(Love()).Happened(Death()));
    }
}