using LanguageExt;

namespace FunctionalStoryteller;

public class Story
{
    internal readonly Seq<Scene> scenes;
    internal Story(Seq<Scene> scenes) => this.scenes = scenes;

    public bool IsAlive(Character who) => !scenes.OfType<DeathScene>().Any(x => x.IsInTheTomb(who));
    public bool WasRejected(Character who) => FirstLoveOf(who) != WhoLoves(who);

    public Option<Character> WhoLoves(Character loved)
        => this.All<LoveScene>(loved)
            .Where(scene => FellInLove(loved, scene))
            .Map(scene => scene.PotentialLoverOf(loved))
            .FirstOrDefault()
            .Match
            (
                lover => IsAlive(loved) == IsAlive(lover) ? lover : Option<Character>.None,
                Option<Character>.None
            );

    bool FellInLove(Character who, LoveScene when) => this.First<LoveScene>(of: when.LoverOf(who)).Equals(when);
    public Option<Character> FirstLoveOf(Character who)
        => this.First<LoveScene>(of: who).Bind(s => s.PotentialLoverOf(who));

    public bool SharingAstralPlane(string theOne, string theOther) => IsAlive(theOne) == IsAlive(theOther);

    public bool IsHeartbroken(Character who)
        => FirstLoveOf(who)
            .Match
            (
                x => scenes.OfType<DeathScene>().Any(s => s.AreInTheCast(who, x)),
                false
            );

    public override bool Equals(object obj)
        => obj is Story story &&
           scenes.SequenceEqual(story.scenes);
}