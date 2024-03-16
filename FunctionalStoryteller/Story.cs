using LanguageExt;

namespace FunctionalStoryteller;

public class Story
{
    internal readonly Seq<Scene> scenes;
    internal Story(Seq<Scene> scenes) => this.scenes = scenes;

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

    public bool SharingAstralPlane(Character theOne, Character theOther) =>
        Is(Specs.Alive(theOne)) == Is(Specs.Alive(theOther));

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

    public bool Is(params Spec[] allSpecs) => allSpecs.All(spec => spec.IsSatisfiedBy(this));

    public Seq<Story> asfsafasf(int until)
    {
        var result = new List<Story>();
        for (var i = 1; i <= until; i++)
        {
            result.Add(new Story(scenes.Take(i).ToSeq()));
        }

        return result.ToSeq();
    }

    public Seq<Story> asfsafasf()
    {
        return asfsafasf(scenes.Length);
    }

    public Scene TheLater(Scene theOne, Scene theOther)
        => scenes.ToList().LastIndexOf(theOne) > scenes.ToList().LastIndexOf(theOther) ? theOne : theOther;

    public Option<Scene> TheLater(Option<Scene> theOne, Option<Scene> theOther)
        => theOne.Map(scenes.ToList().LastIndexOf) > theOther.Map(scenes.ToList().LastIndexOf)
            ? theOne
            : theOther;

    public Option<Scene> TheLater<T>(Func<T, bool> wherein) where T : Scene
        => scenes.OfType<T>().LastOrDefault(wherein);
}