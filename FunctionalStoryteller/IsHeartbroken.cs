using LanguageExt.UnsafeValueAccess;

namespace FunctionalStoryteller;

public class IsHeartbroken : Spec
{
    readonly Character who;
    public IsHeartbroken(Character who) => this.who = who;

    public override bool IsSatisfiedBy(Story story)
    {
        var firstLove = story.FirstLoveOf(who);
        if (firstLove.IsNone) return false;
        if (!story.scenes.OfType<DeathScene>().Any(x => x.IsInTheTomb(firstLove.ValueUnsafe()) && x.IsInTheCast(who)))
            return false;

        var lastMeetingWithLove = story.scenes.LastOrDefault(x => x.IsInTheCast(who) && x.IsInTheCast(firstLove.ValueUnsafe()));
        var deathOfLover = story.scenes.OfType<DeathScene>().LastOrDefault(x => x.IsInTheTomb(firstLove.ValueUnsafe()));
        var theLater = story.TheLater(lastMeetingWithLove, deathOfLover);

        return theLater == deathOfLover;
    }
}