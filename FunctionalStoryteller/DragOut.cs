using LanguageExt;

namespace FunctionalStoryteller;

public sealed class DragOut : Command
{
    readonly int vignette;

    public DragOut(int vignette)
    {
        this.vignette = vignette;
    }

    public override StoryBoard SketchIn(StoryBoard subject)
    {
        return subject.Remove(vignette);
    }

    public override Option<Event> sdfsafas()
    {
        return Events.SceneDetachedFromVignette(vignette);
    }
}