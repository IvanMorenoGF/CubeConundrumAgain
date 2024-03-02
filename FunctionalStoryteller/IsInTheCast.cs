namespace FunctionalStoryteller;

public class IsInTheCast : Spec
{
    readonly Character who;
    public IsInTheCast(Character who) => this.who = who;
    public override bool IsSatisfiedBy(Story story) => story.scenes.Any(x => x.IsInTheCast(who));
}