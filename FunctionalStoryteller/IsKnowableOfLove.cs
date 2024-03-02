namespace FunctionalStoryteller;

public class IsKnowableOfLove : Spec
{
    readonly Character who;

    public IsKnowableOfLove(Character who)
    {
        this.who = who;
    }

    public override bool IsSatisfiedBy(Story story)
        => story.All<LoveScene>(of: who).Any(WasInLoveWithSomeone);

    bool WasInLoveWithSomeone(LoveScene scene) => scene.PotentialLoverOf(who).IsSome;
}