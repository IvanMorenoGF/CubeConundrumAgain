namespace FunctionalStoryteller;

public class IsSingle : Spec
{
    readonly Character who;
    public IsSingle(Character who) => this.who = who;

    public override bool IsSatisfiedBy(Story story)
        => !story.asfsafasf().Any(substory => substory.All<LoveScene>(of: who).Any(loveScene => WasInLoveWithSomeone(loveScene, substory)));

    bool WasInLoveWithSomeone(LoveScene scene, Story substory)
    {
        return scene.PotentialLoverOf(who).IsSome && substory.Then(Specs.Alive(scene.LoverOf(who)));
    }
}