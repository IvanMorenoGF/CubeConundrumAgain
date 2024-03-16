using LanguageExt;

namespace FunctionalStoryteller;

public class IsAlive : Spec
{
    readonly Character who;
    public IsAlive(Character who) => this.who = who;

    public override bool IsSatisfiedBy(Story story)
        => new IsInTheCast(who).IsSatisfiedBy(story) &&
           story.AreInOrder
           (
               story.TheLater<DeathScene>(wherein: x => x.IsInTheTomb(who)),
               story.TheLater<ReviveScene>(wherein: x => x.IsInTheCast(who))
           );
}