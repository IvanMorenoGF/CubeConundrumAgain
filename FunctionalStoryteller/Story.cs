using LanguageExt;

namespace FunctionalStoryteller;

public class Story
{
    internal readonly Seq<Scene> scenes;
    internal Story(Seq<Scene> scenes) => this.scenes = scenes;
    public Seq<Character> Casting => scenes.Bind(s => s.Cast).Distinct().ToSeq();

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
        Then(Specs.Alive(theOne)) == Then(Specs.Alive(theOther));

    public override bool Equals(object obj)
        => obj is Story story &&
           scenes.SequenceEqual(story.scenes);

    public bool Then(params Spec[] allSpecs) => new AndSpec(allSpecs).IsSatisfiedBy(this);

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

    public Option<Scene> TheLater(Option<Scene> theOne, Option<Scene> theOther)
        => theOne.Map(scenes.ToList().LastIndexOf) > theOther.Map(scenes.ToList().LastIndexOf)
            ? theOne
            : theOther;

    public Option<Scene> TheLater<T>(Func<T, bool> wherein) where T : Scene
        => scenes.OfType<T>().LastOrDefault(wherein);

    public bool AreInOrder(Option<Scene> theFirst, Option<Scene> theLast)
    {
        return TheLater(theFirst, theLast) == theLast;
    }

    public Story CutUntil(Scene of)
    {
        return asfsafasf(scenes.ToList().IndexOf(of) + 1).Last;
    }

    public Seq<Scene> ScenesOf(Character who)
    {
        return scenes.Where(x => x.IsInTheCast(who));
    }
}