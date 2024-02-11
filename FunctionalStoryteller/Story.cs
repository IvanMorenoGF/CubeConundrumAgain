using LanguageExt;
using static LanguageExt.Option<FunctionalStoryteller.Character>;

namespace FunctionalStoryteller;

public class Story
{
    internal readonly Seq<Scene> scenes;
    internal Story(Seq<Scene> scenes) => this.scenes = scenes;
    public bool IsAlive(Character who) => !scenes.OfType<DeathScene>().Any(x => x.IsInTheTomb(who));
    Option<LoveScene> FirstLoveScene() => scenes.First(x => x is LoveScene) as LoveScene;
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
        => FirstLoveStoryOf(who).Match
            (
                scene => scene.LoverOf(who),
                () => None
            );

    Option<LoveScene> FirstLoveStoryOf(Character who)
        => scenes.Any(x => PartOfLoveStory(who, x))
            ? scenes.First(x => PartOfLoveStory(who, x)) as LoveScene
            : Option<LoveScene>.None;

    bool PartOfLoveStory(Character who) => scenes.Any(x => PartOfLoveStory(who, x));
    static bool PartOfLoveStory(Character who, Scene x) => x is LoveScene && x.IsInTheCast(who);
}