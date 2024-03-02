using LanguageExt;

namespace FunctionalStoryteller;

public sealed class MoveCharacterToAnotherScene : Command
{
    readonly int fromVignette;
    readonly int toVignette;
    readonly int fromPosition;
    readonly int toPosition;

    public MoveCharacterToAnotherScene(int fromVignette, int toVignette, int fromPosition, int toPosition)
    {
        if (fromVignette == toVignette) 
            throw new ArgumentException("The from and to vignettes must be different");
        
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

    public override Option<Event> sdfsafas()
    {
        throw new NotImplementedException();
    }
}