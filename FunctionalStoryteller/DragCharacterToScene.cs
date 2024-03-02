namespace FunctionalStoryteller;

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

    public override Event sdfsafas()
    {
        throw new NotImplementedException();
    }
}