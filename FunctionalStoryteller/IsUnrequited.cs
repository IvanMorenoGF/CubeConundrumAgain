namespace FunctionalStoryteller;

public class IsUnrequited : Spec
{
    readonly Character who;
    public IsUnrequited(Character who) => this.who = who;

    public override bool IsSatisfiedBy(Story story) 
        => story.FirstLoveOf(who)
            .Match
            (
                x => story.scenes.OfType<LoveScene>().Any(s => s.AreInTheCast(who, x)),
                false
            );
}