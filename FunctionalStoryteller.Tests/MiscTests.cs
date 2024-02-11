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
    public void afsafas()
    {
        StoryBoard.Blank(1).TellAt(1, Death()).Tell().Should().NotBeEquivalentTo(OnceUponATime());
    }
}

public class StoryBoard
{
    Scene asfsaf;

    StoryBoard(Scene what)
    {
        asfsaf = what;
    }

    public static StoryBoard Blank(int howMuchVignettes)
    {
        return new StoryBoard(null);
    }
    
    public StoryBoard TellAt(int vignette, Scene what)
    {
        return new StoryBoard(what);
    }

    public Story Tell()
    {
        if(asfsaf == null) return OnceUponATime();
        
        return OnceUponATime().Happened(asfsaf);
    }
}