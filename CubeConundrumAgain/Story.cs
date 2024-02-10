using LanguageExt;
using static LanguageExt.Lst<LanguageExt.Option<CubeConundrumAgain.Scene>>;
using static LanguageExt.Option<CubeConundrumAgain.Character>;

namespace CubeConundrumAgain;

public class Story
{
    readonly Seq<Scene> scenes;
    readonly Lst<Option<Scene>> allScenes;

    Story(Lst<Option<Scene>> scene)
    {
        this.allScenes = scene;
        scenes = scene.AsEnumerable().Select(x => x.Match(scene => scene, () => new Scene("", ""))).ToSeq();
    }

    public static Story OnceUponATime() => new(Empty);
    public Story Happened(Option<Scene> what) => new(allScenes.Add(what));

    public bool IsAlive(Character who) => !scenes.AsEnumerable().Any(x => x.IsInTheTomb(who));

    public bool Loves(string from, string to)
        => scenes.AsEnumerable().Any(x => x.AreCoupled(from, to));

    Option<Scene> FirstLoveScene() => scenes.AsEnumerable().First(x => x.IsLoveScene);

    public bool IsHeartbroken(Character who) => WhomLoves(who) != WhoLoves(who);

    public Option<Character> WhoLoves(Character loved)
        => FirstLoveStoryOf(loved)
            .Match
            (
                firstSceneWithLoved => WhomLoves(firstSceneWithLoved.LoverOf(loved))
                    .Match
                    (
                        x => x == loved ? firstSceneWithLoved.LoverOf(loved) : None,
                        None
                    ),
                None
            );

    public Option<Character> WhomLoves(Character who)
        => PartOfLoveStory(who)
            ? FirstLoveScene().Match
            (
                scene => scene.LoverOf(who),
                () => None
            )
            : None;

    Option<Scene> FirstLoveStoryOf(Character who)
        => scenes.Any(x => PartOfLoveStory(who, x))
            ? scenes.First(x => PartOfLoveStory(who, x))
            : Option<Scene>.None;

    bool PartOfLoveStory(Character who)
        => scenes.Any(x => PartOfLoveStory(who, x));

    static bool PartOfLoveStory(Character who, Scene x)
        => x.IsLoveScene && x.IsInTheCast(who);
}