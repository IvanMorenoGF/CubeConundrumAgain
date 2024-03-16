using LanguageExt;
using LanguageExt.UnsafeValueAccess;

namespace FunctionalStoryteller;

public class IsHeartbroken : Spec
{
    readonly Character who;
    public IsHeartbroken(Character who) => this.who = who;

    public override bool IsSatisfiedBy(Story story) 
        => story.AreInOrder
        (
            story.scenes.LastOrDefault(x => x.IsInTheCast(who) && x.IsInTheCast(story.FirstLoveOf(who))),
            story.scenes.OfType<DeathScene>().LastOrDefault(x => x.IsInTheTomb(story.FirstLoveOf(who).ValueUnsafe()) && x.IsInTheCast(who))
        );
}