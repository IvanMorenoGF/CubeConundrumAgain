namespace FunctionalStoryteller;

public class IsKnowledgestOfLove : Spec
{
    readonly Character who;
    public IsKnowledgestOfLove(Character who) => this.who = who;

    public override bool IsSatisfiedBy(Story story)
        => story.asfsafasf().Any(substory => substory.All<LoveScene>(of: who).Any(loveScene => WasInLoveWithSomeone(loveScene, substory)));

    bool WasInLoveWithSomeone(LoveScene scene, Story substory)
    {
        return scene.PotentialLoverOf(who).IsSome && substory.Is(Specs.Alive(scene.LoverOf(who)));
    }
}