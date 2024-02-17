using FluentAssertions;
using static FunctionalStoryteller.Scene;
using static FunctionalStoryteller.StoryBoard;
using static FunctionalStoryteller.Storyteller;
using static FunctionalStoryteller.Command;

namespace FunctionalStoryteller.Tests;

public class CommandTests
{
    [Test]
    public void DragSceneToVignette_Command()
    {
        DragTo(vignette: 1, Death())
            .SketchIn(Blank(vignettes: 1)).Tell()
            .Should().Be(OnceUponATime().Happened(Death()));
    }

    [Test]
    public void DragSceneToVignette_OverridesExistingScene()
    {
        DragTo(vignette: 1, Love())
            .SketchIn(InspireFrom(OnceUponATime().Happened(Death()))).Tell()
            .Should().Be(OnceUponATime().Happened(Love()));
    }

    [Test]
    public void DragSceneFromOtherVignette()
    {
        Drag(fromVignette: 1, toVignette: 2)
            .SketchIn(Blank(vignettes: 2).PutIn(1, Death()))
            .Should().BeEquivalentTo(Blank(2).PutIn(2, Death()));
    }
}