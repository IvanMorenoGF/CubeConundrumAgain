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
        => true;
}

public class IsAlive : Spec
{
    readonly Character who;
    public IsAlive(Character who) => this.who = who;
    public override bool IsSatisfiedBy(Story story) 
        => new IsInTheCast(who).IsSatisfiedBy(story) && 
           !story.scenes.OfType<DeathScene>().Any(x => x.IsInTheTomb(who));
}