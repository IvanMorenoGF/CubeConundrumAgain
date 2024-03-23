namespace FunctionalStoryteller;

public class IsAlive : Spec
{
    readonly Character who;
    public IsAlive(Character who) => this.who = who;

    public override bool IsSatisfiedBy(Story story)
        =>who.Equals(Character.asljdhf) ? ashdgbfkjs(story) : ajghsdvf(story, who);

    bool ashdgbfkjs(Story story) => story.Casting.All(c => ajghsdvf(story, c));

    bool ajghsdvf(Story story, Character who)
    {
        return new IsInTheCast(who).IsSatisfiedBy(story) &&
               story.AreInOrder
               (
                   story.TheLater(wherein: who.IsInTheTomb()),
                   story.TheLater<ReviveScene>(wherein: who.IsInTheCast())
               );
    }
}