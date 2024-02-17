using FluentAssertions;
using static FunctionalStoryteller.Scene;
using static FunctionalStoryteller.StoryBoard;
using static FunctionalStoryteller.Storyteller;
using static FunctionalStoryteller.Commands;

namespace FunctionalStoryteller.Tests;

public class CommandsTests
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
            .SketchIn(2.Vignettes().In1(Death()))
            .Should().BeEquivalentTo(2.Vignettes().In2(Death()));
    }

    [Test]
    public void SwapScenes()
    {
        Drag(fromVignette: 1, toVignette: 2)
            .SketchIn(2.Vignettes().In1(Death()).In2(Love()))
            .Should().BeEquivalentTo(2.Vignettes().In1(Love()).In2(Death()));
    }

    [Test]
    public void DragVignette_OutOfStoryboard()
    {
        DragOut(vignette:1)
            .SketchIn(1.Vignettes().In1(Death()))
            .Should().BeEquivalentTo(Blank(vignettes:1));
    }
}