using LanguageExt;
using static LanguageExt.Lst<LanguageExt.Option<CubeConundrumAgain.Scene>>;
using static LanguageExt.Option<CubeConundrumAgain.Character>;

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

    Option<Scene> FirstLoveScene()
    {
        return allScenes.First(x => x.IsSome && ((Scene)x).IsLoveScene);
    }

    public bool IsHeartbroken(Character who) => WhomLoves(who) != WhoLoves(who);

    public Option<Character> WhoLoves(Character loved)
    {
        if (!allScenes.Any(x => x.IsSome && ((Scene)x).IsLoveScene && ((Scene)x).IsInTheCast(loved)))
            return None;
        
        var firstSceneWithLoved =
            allScenes.First(x => x.IsSome && ((Scene)x).IsLoveScene && ((Scene)x).IsInTheCast(loved));
        
        var aksdf = firstSceneWithLoved.Match
        (
            scene => scene.LoverOf(loved),
            () => new Character("")
        );
        return WhomLoves(aksdf).Match(x => x == loved ? aksdf : None, None);
    }

    public Option<Character> WhomLoves(Character who)
    {
        if (!allScenes.Any(x => x.IsSome && ((Scene)x).IsLoveScene && ((Scene)x).IsInTheCast(who)))
            return None;

        return FirstLoveScene().Match
        (
            scene => scene.LoverOf(who),
            () => new Character("")
        );
    }
}