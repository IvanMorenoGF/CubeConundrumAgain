using FluentAssertions;
using static FunctionalStoryteller.Commands;
using static FunctionalStoryteller.Scenes;
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
            .SketchIn(1.Vignettes().In1(Solitude()))
            .Should().NotBe(Blank(1).In1(Solitude()));
    }

    [Test]
    public void TellStory_ByDraggingCharacters()
    {
        DragTo(vignette: 1, where: 2, Adam)
            .SketchIn(1.Vignettes().In1(Death()))
            .Tell().Should().Be(OnceUponATime().Happened(Death().Of(Adam)));
    }

    [Test]
    public void DragOut_Command()
    {
        DragOut(vignette: 1, where: 1)
            .SketchIn(1.Vignettes().In1(Solitude().Of(Adam)))
            .Should().Be(Blank(1).In1(Solitude()));
    }

    [Test]
    public void DragCharacter_WithinSameScene()
    {
        DragTo(vignette: 1, from: 1, to: 2)
            .SketchIn(1.Vignettes().In1(Death().WatchedBy(Eve)))
            .Should().Be(1.Vignettes().In1(Death().Of(Eve)));
    }

    [Test]
    public void SwapCharacters()
    {
        DragTo(vignette: 1, from: 1, to: 2)
            .SketchIn(1.Vignettes().In1(Death().Of(Adam).WatchedBy(Eve)))
            .Should().Be(1.Vignettes().In1(Death().Of(Eve).WatchedBy(Adam)));
    }

    [Test]
    public void DragCharacter_ToAnotherScene()
    {
        DragTo(fromVignette: 1, toVignette: 2, fromPosition: 1, toPosition: 2)
            .SketchIn(2.Vignettes().In1(Death().WatchedBy(Adam)).In2(Love()))
            .Should().Be(2.Vignettes().In1(Death()).In2(Love().Between(NobodyElse, Adam)));

        DragTo(fromVignette: 1, toVignette: 2, fromPosition: 1, toPosition: 2)
            .SketchIn(2.Vignettes().In1(Death().WatchedBy(Adam)).In2(Love().Between(NobodyElse, Eve)))
            .Should().Be(2.Vignettes().In1(Death()).In2(Love().Between(NobodyElse, Adam)));
        
        DragTo(fromVignette: 1, toVignette: 2, fromPosition: 1, toPosition: 2)
            .SketchIn(2.Vignettes().In1(Death().WatchedBy(Adam)).In2(Love().Between(Adam, NobodyElse)))
            .Should().Be(2.Vignettes().In1(Death()).In2(Love().Between(NobodyElse, Adam)));
    }
}