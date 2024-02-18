using FluentAssertions;
using static FunctionalStoryteller.Commands;
using static FunctionalStoryteller.StoryBoard;
using static FunctionalStoryteller.Storyteller;
using static FunctionalStoryteller.Tests.CharactersToTestsWith;

namespace FunctionalStoryteller.Tests;

public class SceneCommandsTests
{
    [Test]
    public void DragCharacter_ToVignette_DoesNothing()
    {
        DragTo(vignette: 1, Adam).SketchIn(Blank(1)).Should().Be(Blank(1));
    }

    [Test]
    public void DragCharacter_ToScene()
    {
        DragTo(vignette: 1, where: 1, Adam)
            .SketchIn(1.Vignettes().In1(Scenes.Solitude()))
            .Should().NotBe(Blank(1).In1(Scenes.Solitude()));
    }

    [Test]
    public void TellStory_ByDraggingCharacters()
    {
        DragTo(vignette: 1, where: 2, Adam)
            .SketchIn(1.Vignettes().In1(Scenes.Death()))
            .Tell().Should().Be(OnceUponATime().Happened(Scenes.Death().Of(Adam)));
    }

    [Test]
    public void DragOut_Command()
    {
        DragOut(vignette: 1, where: 1)
            .SketchIn(1.Vignettes().In1(Scenes.Solitude().Of(Adam)))
            .Should().Be(Blank(1).In1(Scenes.Solitude()));
    }

    [Test]
    public void DragCharacter_WithinSameScene()
    {
        DragTo(vignette: 1, from: 1, to: 2)
            .SketchIn(1.Vignettes().In1(Scenes.Death().WatchedBy(Eva)))
            .Should().Be(1.Vignettes().In1(Scenes.Death().Of(Eva)));
    }

    [Test]
    public void SwapCharacters()
    {
        DragTo(vignette: 1, from: 1, to: 2)
            .SketchIn(1.Vignettes().In1(Scenes.Death().Of(Adam).WatchedBy(Eva)))
            .Should().Be(1.Vignettes().In1(Scenes.Death().Of(Eva).WatchedBy(Adam)));
    }

    [Test]
    public void DragCharacter_ToAnotherScene()
    {
        DragTo(fromVignette: 1, toVignette: 2, fromPosition: 1, toPosition: 2)
            .SketchIn(2.Vignettes().In1(Scenes.Death().WatchedBy(Adam)).In2(Scenes.Love()))
            .Should().Be(2.Vignettes().In1(Scenes.Death()).In2(Scenes.Love().Between(NobodyElse, Adam)));

        DragTo(fromVignette: 1, toVignette: 2, fromPosition: 1, toPosition: 2)
            .SketchIn(2.Vignettes().In1(Scenes.Death().WatchedBy(Adam)).In2(Scenes.Love().Between(NobodyElse, Eva)))
            .Should().Be(2.Vignettes().In1(Scenes.Death()).In2(Scenes.Love().Between(NobodyElse, Adam)));
        
        DragTo(fromVignette: 1, toVignette: 2, fromPosition: 1, toPosition: 2)
            .SketchIn(2.Vignettes().In1(Scenes.Death().WatchedBy(Adam)).In2(Scenes.Love().Between(Adam, NobodyElse)))
            .Should().Be(2.Vignettes().In1(Scenes.Death()).In2(Scenes.Love().Between(NobodyElse, Adam)));
    }
}