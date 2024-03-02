namespace FunctionalStoryteller;

public class IsInLoveWith : Spec
{
    readonly Character who;
    readonly Character whom;

    public IsInLoveWith(Character who, Character whom)
    {
        this.who = who;
        this.whom = whom;
    }

    public override bool IsSatisfiedBy(Story story)
        => story.First<LoveScene>(of: who).Match
           (
               Some: scene => scene.PotentialLoverOf(who) == whom,
               None: () => false
           );
}