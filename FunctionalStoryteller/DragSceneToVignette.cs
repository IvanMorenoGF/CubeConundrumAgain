namespace FunctionalStoryteller;

public sealed class DragSceneToVignette : Command
{
    readonly int index;
    readonly Scene scene;

    public DragSceneToVignette(int index, Scene scene)
    {
        this.index = index;
        this.scene = scene;
    }

    public override StoryBoard SketchIn(StoryBoard subject)
    {
        return subject.PutIn(index, scene);
    }

    public override Event sdfsafas() => Events.SceneAttachedToVignette(index, scene);
}