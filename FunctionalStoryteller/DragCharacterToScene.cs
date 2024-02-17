namespace FunctionalStoryteller;

public sealed class DragCharacterWithinScene : Command
{
    readonly int vignette;
    readonly int from;
    readonly int to;

    public DragCharacterWithinScene(int vignette, int from, int to)
    {
        this.vignette = vignette;
        this.from = from;
        this.to = to;
    }

    public override StoryBoard SketchIn(StoryBoard subject)
        => subject.SceneAt(vignette).Match
        (
            scene => subject.Compose
            (
                Commands.DragTo(vignette, to, scene.CharacterAt(from)),
                Commands.DragOut(vignette, from)
            ), () => throw new ArgumentOutOfRangeException(nameof(vignette))
        );
}
public sealed class DragCharacterToScene : Command
{
    readonly int vignette;
    readonly int where;
    readonly Character who;

    public DragCharacterToScene(int vignette, int where, Character who)
    {
        this.vignette = vignette;
        this.where = where;
        this.who = who;
    }


    public override StoryBoard SketchIn(StoryBoard subject)
    {
        var newScene =  subject.SceneAt(vignette).Match(scene => scene.PlaceAt(where, who), () => throw new ArgumentOutOfRangeException(nameof(vignette)));
        return subject.PutIn(vignette, newScene);
    }
}