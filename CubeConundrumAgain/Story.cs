using LanguageExt;
using static LanguageExt.Lst<LanguageExt.Option<CubeConundrumAgain.Scene>>;

namespace CubeConundrumAgain;

public class Story
{
    readonly Lst<Option<Scene>> allScenes;
    Story(Option<Scene> scene) => allScenes = Empty.Add(scene);
    Story(Lst<Option<Scene>> scene) => this.allScenes = scene;
    public static Story OnceUponATime() => new(Option<Scene>.None);
    public bool IsAlive(string who) => allScenes.Last().Match(where => !where.IsInTheTomb(who), () => true);
    public Story Happened(Option<Scene> what) => new(allScenes.Add(what));

    public bool Loves(string from, string to)
        => allScenes.First(x => x.IsSome).Match
        (
            where => where.AreCoupled(from, to),
            () => false
        );

    public Character WhomLoves(string lover)
        => FirstLoveScene().Match
        (
            scene => scene.LoverOf(lover),
            () => new Character("")
        );

    private Option<Scene> FirstLoveScene()
    {
        return allScenes.First(x => x.IsSome && ((Scene)x).IsLoveScene);
    }

    public Character WhoLoves(Character loved)
    {
        var firstSceneWithLoved =
            allScenes.First(x => x.IsSome && ((Scene)x).IsLoveScene && ((Scene)x).IsInTheCast(loved));
        var aksdf = firstSceneWithLoved.Match
        (
            scene => scene.LoverOf(loved),
            () => new Character("")
        );
        return WhomLoves(aksdf) == loved ? aksdf : "";
    }

    public bool IsHeartbroken(Character who) => WhomLoves_New(who) != WhoLoves_New(who);

    public Option<Character> WhoLoves_New(Character loved)
    {
        if (!allScenes.Any(x => x.IsSome && ((Scene)x).IsLoveScene && ((Scene)x).IsInTheCast(loved)))
            return Option<Character>.None;
        
        return WhoLoves(loved) == "" ? Option<Character>.None : WhoLoves(loved);
    }

    public Option<Character> WhomLoves_New(Character who)
    {
        if (!allScenes.Any(x => x.IsSome && ((Scene)x).IsLoveScene && ((Scene)x).IsInTheCast(who)))
            return Option<Character>.None;

        return WhomLoves(who) == "" ? Option<Character>.None : WhomLoves(who);
    }
}