using FluentAssertions;
using static FunctionalStoryteller.Commands;
using static FunctionalStoryteller.Scene;
using static FunctionalStoryteller.StoryBoard;
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
        DragTo(vignette: 1, Adam).SketchIn(1.Vignettes().In1(Solitude())).Should().NotBe(Blank(1).In1(Solitude()));
    }
}