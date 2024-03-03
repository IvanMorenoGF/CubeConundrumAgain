namespace FunctionalStoryteller;

public class IsAlive : Spec
{
    readonly Character who;
    public IsAlive(Character who) => this.who = who;

    public override bool IsSatisfiedBy(Story story)
    {
        if (story.scenes.OfType<ReviveScene>().Any(x => x.IsInTheCast(who)))
            return true;
        
        return new IsInTheCast(who).IsSatisfiedBy(story) &&
               !story.scenes.OfType<DeathScene>().Any(x => x.IsInTheTomb(who));
    }
}