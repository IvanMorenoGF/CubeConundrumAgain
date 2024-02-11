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
    public void CreateBlankStoryboard()
    {
        StoryBoard.Blank(2).IsEmpty().Should().BeTrue();
        StoryBoard.Blank(2).TellAt(1, Scene.Death()).IsEmpty().Should().BeFalse();
    }
}

public class StoryBoard
{
    Scene asfsaf;

    StoryBoard(Scene what)
    {
        asfsaf = what;
    }

    public static StoryBoard Blank(int i)
    {
        return new StoryBoard(null);
    }

    public bool IsEmpty()
    {
        return asfsaf == null;
    }

    public StoryBoard TellAt(int when, Scene what)
    {
        return new StoryBoard(what);
    }
}