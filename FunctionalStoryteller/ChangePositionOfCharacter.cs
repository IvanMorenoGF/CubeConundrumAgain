namespace FunctionalStoryteller;

public sealed class MoveCharacterToAnotherScene : Command
{
    readonly int fromVignette;
    readonly int toVignette;
    readonly int fromPosition;
    readonly int toPosition;

    public MoveCharacterToAnotherScene(int fromVignette, int toVignette, int fromPosition, int toPosition)
    {
        this.fromVignette = fromVignette;
        this.toVignette = toVignette;
        this.fromPosition = fromPosition;
        this.toPosition = toPosition;
    }

    public override StoryBoard SketchIn(StoryBoard subject)
        => subject.SceneAt(fromVignette).Match
        (
            scene => subject.Compose
            (
                Commands.DragTo(toVignette, toPosition, scene.CharacterAt(fromPosition)),
                Commands.DragOut(fromVignette, fromPosition)
            ), () => throw new ArgumentOutOfRangeException(nameof(fromVignette))
        );
}

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