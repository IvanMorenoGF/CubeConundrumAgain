using LanguageExt;

namespace CubeConundrumAgain;

public class Story
{
    Option<Scene> scene;
    Story(Option<Scene> scene) => this.scene = scene;
    public static Story OnceUponATime() => new(Option<Scene>.None);
    public bool IsAlive(string who) => scene.Match(where => !where.IsInTheTomb(who), () => true);
    public Story Happened(Option<Scene> what) => new(what);
}