using FluentAssertions;

namespace FunctionalStoryteller.Tests;

public class asldkfjaklsdfj
{
    [Test]
    public void DragSceneToVignette_Command()
    {
        var doc = StoryBoard.Blank(vignettes: 1);

        var sut = new DragSceneToVignette(1, Scene.Death());
        StoryBoard result = sut.alksdjfIn(doc);

        result.Tell().Should().Be(Storyteller.OnceUponATime().Happened(Scene.Death()));
    }
}

public sealed class DragSceneToVignette
{
    readonly int index;
    readonly Scene scene;

    public DragSceneToVignette(int index, Scene scene)
    {
        this.index = index;
        this.scene = scene;
    }

    public StoryBoard alksdjfIn(StoryBoard subject)
    {
        return subject.lkajsdlfkj(index, scene);
    }
}