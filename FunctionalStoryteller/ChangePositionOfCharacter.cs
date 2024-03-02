namespace FunctionalStoryteller;

public sealed class ChangePositionOfCharacter : Command
{
    readonly int vignette;
    readonly int from;
    readonly int to;

    public ChangePositionOfCharacter(int vignette, int from, int to)
    {
        if (from == to) 
            throw new ArgumentException("The from and to positions must be different");
        
        this.vignette = vignette;
        this.from = from;
        this.to = to;
    }

    public override StoryBoard SketchIn(StoryBoard subject)
        => subject.SceneAt(vignette).Match
        (
            scene => subject.Compose
            (
                Commands.DragTo(vignette, where: to, who: scene.CharacterAt(from)),
                Commands.DragTo(vignette, where: from, who: scene.CharacterAt(to))
            ), () => throw new ArgumentOutOfRangeException(nameof(vignette))
        );

    public override Event sdfsafas()
    {
        throw new NotImplementedException();
    }
}