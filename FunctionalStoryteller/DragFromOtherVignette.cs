namespace FunctionalStoryteller;

public sealed class DragFromOtherVignette : Command
{
    readonly int fromVignette;
    readonly int toVignette;

    public DragFromOtherVignette(int fromVignette, int toVignette)
    {
        this.fromVignette = fromVignette;
        this.toVignette = toVignette;
    }

    public override StoryBoard SketchIn(StoryBoard subject)
    {
        return subject.Swap(fromVignette, toVignette);
    }

    public override Event sdfsafas() => Events.ScenesSwapped(fromVignette, toVignette);
}