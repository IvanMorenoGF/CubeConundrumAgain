using FluentAssertions;
using LanguageExt;
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
        StoryBoard.Blank(1).TellAt(1, Death()).Tell().Should().NotBeEquivalentTo(OnceUponATime());
        StoryBoard.Blank(1).TellAt(1, Death()).Tell().Should().BeEquivalentTo(OnceUponATime().Happened(Death()));
    }

    [Test]
    public void Compose_TwoScenes()
    {
        StoryBoard.Blank(2)
            .TellAt(1, Death())
            .TellAt(2, Death().Buried("Adan"))
            .Tell()
            .Should().BeEquivalentTo(OnceUponATime().Happened(Death()).Happened(Death().Buried("Adan")));
    }

    [Test]
    public void SwapScenes()
    {
        StoryBoard.Blank(2)
            .TellAt(1, Death())
            .TellAt(2, Death().Buried("Adan"))
            .Swap(1, 2)
            .Tell()
            .Should().BeEquivalentTo(OnceUponATime().Happened(Death().Buried("Adan")).Happened(Death()));
    }

    [Test]
    public void TellStoryUntil()
    {
        StoryBoard.Blank(2)
            .TellAt(1, Love())
            .TellAt(2, Death())
            .TellUntil(1)
            .Should().BeEquivalentTo(OnceUponATime().Happened(Love()));
        
        StoryBoard.Blank(20)
            .TellAt(1, Love())
            .TellAt(6, Death())
            .TellAt(17, Death().Buried("Adan"))
            .TellUntil(11)
            .Should().BeEquivalentTo(OnceUponATime().Happened(Love()).Happened(Death()));
    }
}

public class StoryBoard
{
    Option<Scene>[] scenes;

    StoryBoard(int howMuchVignettes)
    {
        scenes = new Option<Scene>[howMuchVignettes];
    }

    public StoryBoard(Option<Scene>[] scenes) => this.scenes = scenes;

    public static StoryBoard Blank(int howMuchVignettes)
    {
        return new StoryBoard(howMuchVignettes);
    }

    public StoryBoard TellAt(int vignette, Scene what)
    {
        var newScenes = new Option<Scene>[scenes.Length];
        scenes.CopyTo(newScenes, 0);
        newScenes[vignette - 1] = what;
        return new StoryBoard(newScenes);
    }
    
    public StoryBoard Swap(int theOne, int theOther)
    {
        var newScenes = new Option<Scene>[scenes.Length];
        scenes.CopyTo(newScenes, 0);
        newScenes[theOne - 1] = scenes[theOther - 1];
        newScenes[theOther - 1] = scenes[theOne - 1];
        return new StoryBoard(newScenes);
    }

    public Story Tell()
        => scenes.Bind(x => x).Aggregate(OnceUponATime(), (current, scene) => current.Happened(scene));

    public Story TellUntil(int vignette) => new StoryBoard(scenes.Take(vignette).ToArray()).Tell();
}