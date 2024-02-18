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
                Commands.DragTo(vignette, from, scene.CharacterAt(to))
            ), () => throw new ArgumentOutOfRangeException(nameof(vignette))
        );
}