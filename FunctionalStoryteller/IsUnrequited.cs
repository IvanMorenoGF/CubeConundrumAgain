namespace FunctionalStoryteller;

public class IsUnrequited : Spec
{
    readonly Character who;
    public IsUnrequited(Character who) => this.who = who;

    public override bool IsSatisfiedBy(Story story) 
        => story.First<LoveScene>(of:who)
            .Match
            (
                scene => !scene.LoverOf(who).Loves(who).IsSatisfiedBy(story),
                false
            );
}