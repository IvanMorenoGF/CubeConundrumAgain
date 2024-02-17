using FluentAssertions;
using static FunctionalStoryteller.Scene;
using static FunctionalStoryteller.StoryBoard;
using static FunctionalStoryteller.Storyteller;
using static FunctionalStoryteller.Command;

namespace FunctionalStoryteller.Tests;

public class asldkfjaklsdfj
{
    [Test]
    public void DragSceneToVignette_Command()
    {
        DragTo(vignette: 1, Death())
            .SketchIn(Blank(vignettes: 1)).Tell()
            .Should().Be(OnceUponATime().Happened(Death()));
    }
}