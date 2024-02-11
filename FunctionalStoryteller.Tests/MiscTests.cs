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
    public void afsafas()
    {
        StoryBoard.Blank(1).TellAt(1, Death()).Tell().Should().NotBeEquivalentTo(OnceUponATime());
        StoryBoard.Blank(1).TellAt(1, Death()).Tell().Should().BeEquivalentTo(OnceUponATime().Happened(Death()));
    }
    
    [Test][Ignore("asfasf")]
    public void fdfasfas()
    {
        StoryBoard.Blank(2)
            .TellAt(1, Death())
            .TellAt(2, Death().Buried("Adan"))
            .Tell()
            .Should().BeEquivalentTo(OnceUponATime().Happened(Death()).Happened(Death().Buried("Adan")));
    }
}

public class StoryBoard
{
    Scene[] scenes;

    StoryBoard(int howMuchVignettes)
    {
        scenes = new Scene[howMuchVignettes];
    }

    public StoryBoard(Scene[] scenes) => this.scenes = scenes;

    public static StoryBoard Blank(int howMuchVignettes)
    {
        return new StoryBoard(howMuchVignettes);
    }
    
    public StoryBoard TellAt(int vignette, Scene what)
    {
        var newScenes = new Scene[scenes.Length];
        scenes.CopyTo(newScenes, 0);
        newScenes[vignette - 1] = what;
        return new StoryBoard(newScenes);
    }

    public Story Tell()
    {
        if(scenes.All(x => x == default)) return OnceUponATime();

        return scenes.Aggregate(OnceUponATime(), (current, scene) => current.Happened(scene));
    }
}