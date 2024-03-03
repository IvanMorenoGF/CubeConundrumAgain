using static FunctionalStoryteller.Specs;

namespace FunctionalStoryteller;

public class IsScared : Spec
{
    readonly Character who;
    public IsScared(Character who) => this.who = who;

    public override bool IsSatisfiedBy(Story story)
        => story.scenes.Any(scene => scene.Cast.Contains(who) && IsSharingCastWithGhost(scene, story));

    bool IsSharingCastWithGhost(Scene scene, Story story) => Not(Alive(OtherThanWho(scene))).IsSatisfiedBy(story);
    Character OtherThanWho(Scene scene) => scene.Cast.First(character => !character.Equals(who));
}