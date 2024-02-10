using LanguageExt;

namespace CubeConundrumAgain;

public class Story
{
    IEnumerable<Option<Scene>> allScenes;
    Story(Option<Scene> scene) => this.allScenes = new[]{scene};
    Story(IEnumerable<Option<Scene>> scene) => this.allScenes = scene;
    public static Story OnceUponATime() => new(Option<Scene>.None);
    public bool IsAlive(string who) => allScenes.Last().Match(where => !where.IsInTheTomb(who), () => true);
    public Story Happened(Option<Scene> what) => new(allScenes.Append(what));

    public bool Loves(string from, string to) 
        => allScenes.First(x => x.IsSome).Match
        (
            where => where.AreCoupled(from, to),
            () => false
        );
}