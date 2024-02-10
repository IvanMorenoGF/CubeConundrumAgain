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

    public string WhomIsInLoveWith(string lover)
        => FirstLoveScene().Match
        (
            scene => scene.LoverOf(lover), 
            () => ""
        );

    private Option<Scene> FirstLoveScene()
    {
        return allScenes.First(x => x.IsSome && ((Scene)x).IsLoveScene);
    }
}
