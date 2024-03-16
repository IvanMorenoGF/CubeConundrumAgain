namespace FunctionalStoryteller;

public class IsAlive : Spec
{
    readonly Character who;
    public IsAlive(Character who) => this.who = who;

    public override bool IsSatisfiedBy(Story story)
    {
        if (!new IsInTheCast(who).IsSatisfiedBy(story)) return false;
        
        var revive = story.scenes.OfType<ReviveScene>().LastOrDefault(x => x.IsInTheCast(who));
        var death = story.scenes.OfType<DeathScene>().LastOrDefault(x => x.IsInTheTomb(who));
        var theLater =  story.TheLater(revive, death);

        return theLater == null || theLater == revive;
    }
}