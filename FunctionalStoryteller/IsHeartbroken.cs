namespace FunctionalStoryteller;

public class IsHeartbroken : Spec
{
    readonly Character who;
    public IsHeartbroken(Character who) => this.who = who;

    public override bool IsSatisfiedBy(Story story)
        => story.IsHeartbroken(who);
}