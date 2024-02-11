using LanguageExt;

namespace FunctionalStoryteller;

public class Story
{
    internal readonly Seq<Scene> scenes;
    internal Story(Seq<Scene> scenes) => this.scenes = scenes;

    public bool Satisfies(params Spec[] spec) => new Composite(spec).SatisfiedBy(this);
    
    public bool IsAlive(Character who) => !scenes.OfType<DeathScene>().Any(x => x.IsInTheTomb(who));
    public bool WasRejected(Character who) => FirstLoveOf(who) != WhoLoves(who);

    public Option<Character> WhoLoves(Character loved)
        => this
            .All<LoveScene>(loved)
            .Where(date => FellInLoveWith(loved, date))
            .Bind(date => date.PotentialLoverOf(loved))
            .FirstOrDefault(lover => SharingAstralPlane(loved, lover));

    bool FellInLoveWith(Character who, LoveScene date) => this.First<LoveScene>(of: date.LoverOf(who)).Equals(date);

    public Option<Character> FirstLoveOf(Character who)
        => this.First<LoveScene>(of: who).Bind(s => s.PotentialLoverOf(who));

    public bool SharingAstralPlane(Character theOne, Character theOther) => IsAlive(theOne) == IsAlive(theOther);

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