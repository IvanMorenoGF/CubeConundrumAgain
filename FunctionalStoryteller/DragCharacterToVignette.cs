namespace FunctionalStoryteller;

public sealed class DragCharacterToVignette : Command
{
    readonly int vignette;
    readonly Character who;

    public DragCharacterToVignette(int vignette, Character who)
    {
        this.vignette = vignette;
        this.who = who;
    }
    
    public override StoryBoard SketchIn(StoryBoard subject) => subject;
    public override Event sdfsafas()
    {
        throw new NotImplementedException();
    }
}