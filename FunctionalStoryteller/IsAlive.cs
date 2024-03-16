using LanguageExt;

namespace FunctionalStoryteller;

public class IsAlive : Spec
{
    readonly Character who;
    public IsAlive(Character who) => this.who = who;

    public override bool IsSatisfiedBy(Story story)
    {
        if (!new IsInTheCast(who).IsSatisfiedBy(story)) return false;

        var revive = story.TheLater<ReviveScene>(wherein: x => x.IsInTheCast(who));
        var death = story.TheLater<DeathScene>(wherein: x => x.IsInTheTomb(who));

        return story.TheLater(revive, death) == revive;
    }
}