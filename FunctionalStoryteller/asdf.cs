namespace FunctionalStoryteller;

public sealed class asdf : Command
{
    readonly int vignette;
    readonly Character who;

    public asdf(int vignette, Character who)
    {
        this.vignette = vignette;
        this.who = who;
    }
    
    public override StoryBoard SketchIn(StoryBoard subject)
    {
        return subject;
    }
}