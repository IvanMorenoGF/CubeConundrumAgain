using LanguageExt;
using static LanguageExt.Option<CubeConundrumAgain.Character>;

namespace CubeConundrumAgain;

public class Story
{
    internal readonly Seq<Scene> scenes;
    internal Story(Seq<Scene> scenes) => this.scenes = scenes;
    public bool IsAlive(Character who) => !scenes.Any(x => x.IsInTheTomb(who));
    Option<Scene> FirstLoveScene() => scenes.First(x => x.IsLoveScene);
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

    bool PartOfLoveStory(Character who) => scenes.Any(x => PartOfLoveStory(who, x));
    static bool PartOfLoveStory(Character who, Scene x) => x.IsLoveScene && x.IsInTheCast(who);
}