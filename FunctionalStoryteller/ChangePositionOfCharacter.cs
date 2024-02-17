namespace FunctionalStoryteller;

public sealed class ChangePositionOfCharacter : Command
{
    readonly int vignette;
    readonly int from;
    readonly int to;

    public ChangePositionOfCharacter(int vignette, int from, int to)
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