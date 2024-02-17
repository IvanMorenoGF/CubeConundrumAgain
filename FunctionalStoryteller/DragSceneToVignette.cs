namespace FunctionalStoryteller;

public sealed class DragSceneToVignette
{
    readonly int index;
    readonly Scene scene;

    public DragSceneToVignette(int index, Scene scene)
    {
        this.index = index;
        this.scene = scene;
    }

    public StoryBoard SketchIn(StoryBoard subject)
    {
        return subject.PutIn(index, scene);
    }
}