namespace FunctionalStoryteller;

public class IsScared : Spec
{
    readonly Character who;
    public IsScared(Character who) => this.who = who;

    public override bool IsSatisfiedBy(Story story)
        => story.scenes.Any(scene => scene.Cast.Contains(who) && !story.SharingAstralPlane(who, OtherThanWho(scene)));

    Character OtherThanWho(Scene scene) => scene.Cast.First(character => !character.Equals(who));
}