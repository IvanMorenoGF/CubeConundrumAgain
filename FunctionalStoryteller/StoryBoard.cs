using LanguageExt;

namespace FunctionalStoryteller;

public class StoryBoard
{
    Option<Scene>[] scenes;

    StoryBoard(int howMuchVignettes)
    {
        scenes = new Option<Scene>[howMuchVignettes];
    }

    public StoryBoard(Option<Scene>[] scenes) => this.scenes = scenes;

    public static StoryBoard Blank(int howMuchVignettes)
    {
        return new StoryBoard(howMuchVignettes);
    }

    public StoryBoard TellAt(int vignette, Scene what)
    {
        var newScenes = new Option<Scene>[scenes.Length];
        scenes.CopyTo(newScenes, 0);
        newScenes[vignette - 1] = what;
        return new StoryBoard(newScenes);
    }
    
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
}