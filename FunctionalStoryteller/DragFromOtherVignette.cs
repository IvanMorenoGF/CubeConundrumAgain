namespace FunctionalStoryteller;

public sealed class DragFromOtherVignette
{
    readonly int fromVignette;
    readonly int toVignette;

    public DragFromOtherVignette(int fromVignette, int toVignette)
    {
        this.fromVignette = fromVignette;
        this.toVignette = toVignette;
    }

    public StoryBoard SketchIn(StoryBoard subject)
    {
        return subject.Swap(fromVignette, toVignette);
    }
}