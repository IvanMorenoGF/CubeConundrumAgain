namespace FunctionalStoryteller;

public class IsAlive : Spec
{
    readonly Character who;
    public IsAlive(Character who) => this.who = who;

    public override bool IsSatisfiedBy(Story story)
    {
        if (!new IsInTheCast(who).IsSatisfiedBy(story)) return false;
        
        if (story.scenes.OfType<ReviveScene>().Any(x => x.IsInTheCast(who)))
            return true;
        
        var revive = story.scenes.OfType<ReviveScene>().LastOrDefault(x => x.IsInTheCast(who));
        var death = story.scenes.OfType<DeathScene>().LastOrDefault(x => x.IsInTheTomb(who));
        var theLater =  story.TheLater(revive, death);
        
        if (theLater == null) return true;

        return theLater == revive;
        return new IsInTheCast(who).IsSatisfiedBy(story) &&
               !story.scenes.OfType<DeathScene>().Any(x => x.IsInTheTomb(who));
    }
}