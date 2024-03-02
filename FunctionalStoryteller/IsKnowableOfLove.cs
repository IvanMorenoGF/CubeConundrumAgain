namespace FunctionalStoryteller;

public class IsKnowableOfLove : Spec
{
    readonly Character who;

    public IsKnowableOfLove(Character who)
    {
        this.who = who;
    }

    public override bool IsSatisfiedBy(Story story)
        => story.First<LoveScene>(of: who).Match
           (
               Some: scene => scene.PotentialLoverOf(who).IsSome,
               None: () => false
           );
}