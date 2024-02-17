namespace FunctionalStoryteller;

public sealed class DragCharacterOutOfScene : Command
{
    readonly int vignette;
    readonly int where;

    public DragCharacterOutOfScene(int vignette, int where)
    {
        this.vignette = vignette;
        this.where = where;
    }

    public override StoryBoard SketchIn(StoryBoard subject)
    {
        var newScene =  subject.SceneAt(vignette).Match(scene => scene.PlaceAt(where, null), () => throw new ArgumentOutOfRangeException(nameof(vignette)));
        return subject.PutIn(vignette, newScene);
    }
}