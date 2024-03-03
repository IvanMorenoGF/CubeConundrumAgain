namespace FunctionalStoryteller;

public class IsScared : Spec
{
    readonly Character who;
    public IsScared(Character who) => this.who = who;

    public override bool IsSatisfiedBy(Story story)
        => true;
}