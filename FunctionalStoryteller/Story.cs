using LanguageExt;

namespace FunctionalStoryteller;

public class Story
{
    internal readonly Seq<Scene> scenes;
    internal Story(Seq<Scene> scenes) => this.scenes = scenes;
    
    public bool IsAlive(Character who) => !scenes.OfType<DeathScene>().Any(x => x.IsInTheTomb(who));
    public bool WasRejected(Character who) => WhomLoves(who) != WhoLoves(who);

    public Option<Character> WhoLoves(Character loved)
        => this.First<LoveScene>(loved)
            .Match
            (
                firstSceneWithLoved => WhomLoves(firstSceneWithLoved.LoverOf(loved))
                    .Match
                    (
                        lover => lover == loved && IsAlive(loved) == IsAlive(firstSceneWithLoved.LoverOf(loved)) ? firstSceneWithLoved.LoverOf(loved) : Option<Character>.None,
                        Option<Character>.None
                    ),
                Option<Character>.None
            );

    public Option<Character> WhomLoves(Character who)
        => this.First<LoveScene>(of: who).Bind(s => s.PotentialLoverOf(who));

    public bool SharingAstralPlane(string theOne, string theOther) => IsAlive(theOne) == IsAlive(theOther);

    public bool IsHeartbroken(Character who) 
        => WhomLoves(who)
            .Match
            (
                x => scenes.OfType<DeathScene>().Any(s => s.AreInTheCast(who, x)),
                false
            );

    public override bool Equals(object obj)
        => obj is Story story &&
           scenes.SequenceEqual(story.scenes);
}