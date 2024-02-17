using LanguageExt;

namespace FunctionalStoryteller;

public sealed class StoryBoard
{
    readonly Option<Scene>[] scenes;

    StoryBoard(int howMuchVignettes)
    {
        scenes = new Option<Scene>[howMuchVignettes];
    }

    public StoryBoard(Option<Scene>[] scenes) => this.scenes = scenes;
    public StoryBoard(IEnumerable<Scene> scenes) => this.scenes = scenes.Map(Option<Scene>.Some).ToArray();

    public static StoryBoard Blank(int vignettes) => new(vignettes);
    public static StoryBoard InspireFrom(Story story) => new(story.scenes);

    public StoryBoard PutIn(int vignette, Scene what)
    {
        if (vignette < 1 || vignette > scenes.Length)
            throw new ArgumentOutOfRangeException(nameof(vignette));

        var newScenes = new Option<Scene>[scenes.Length];
        scenes.CopyTo(newScenes, 0);
        newScenes[vignette - 1] = what;
        return new StoryBoard(newScenes);
    }

    public StoryBoard Remove(int vignette)
    {
        if (vignette < 1 || vignette > scenes.Length)
            throw new ArgumentOutOfRangeException(nameof(vignette));

        var newScenes = new Option<Scene>[scenes.Length];
        scenes.CopyTo(newScenes, 0);
        newScenes[vignette - 1] = Option<Scene>.None;
        return new StoryBoard(newScenes);
    }

    public StoryBoard In1(Scene what) => PutIn(1, what);
    public StoryBoard In2(Scene what) => PutIn(2, what);
    public StoryBoard In3(Scene what) => PutIn(3, what);

    public StoryBoard Swap(int theOne, int theOther)
    {
        var newScenes = new Option<Scene>[scenes.Length];
        scenes.CopyTo(newScenes, 0);
        newScenes[theOne - 1] = scenes[theOther - 1];
        newScenes[theOther - 1] = scenes[theOne - 1];
        return new StoryBoard(newScenes);
    }

    public Story Tell()
        => scenes.Bind(x => x).Aggregate(Storyteller.OnceUponATime(), (current, scene) => current.Happened(scene));

    public Story TellUntil(int vignette) => new StoryBoard(scenes.Take(vignette).ToArray()).Tell();
    public Story TellAllButLast() => TellUntil(scenes.Length - 1);

    public Option<Scene> SceneAt(int vignette)
    {
        if (vignette < 1 || vignette > scenes.Length)
            throw new ArgumentOutOfRangeException(nameof(vignette));

        return scenes[vignette - 1];
    }

    public override bool Equals(object obj)
        => obj is StoryBoard story &&
           scenes.SequenceEqual(story.scenes);

    public override string ToString()
        => scenes.Length switch
        {
            0 => "Empty StoryBoard",
            1 => scenes[0].Match(s => $"Once upon a time, {s}", () => "Empty StoryBoard"),
            _ => string.Join(',', scenes.Select
            (
                (s, i) => s.Match(s => $"In vignette {i + 1}, {s}",
                    () => $"In vignette {i + 1}, nothing")
            ))
        };
}