using LanguageExt;

namespace FunctionalStoryteller;

public static class Scriptwriter
{
    public static bool PartOfAny<T>(this Story story, Character who) where T : Scene
        => story.scenes.OfType<T>().Any(x => x.IsInTheCast(who));
    
    public static Option<T> First<T>(this Story story, Character of) where T : Scene
        => story.PartOfAny<T>(of)
            ? story.scenes.OfType<T>().First(x => x.IsInTheCast(of))
            : Option<T>.None;
    
    public static Seq<T> All<T>(this Story story, Character of) where T : Scene
        => story.PartOfAny<T>(of)
            ? story.scenes.OfType<T>().Where(x => x.IsInTheCast(of)).ToSeq()
            : Seq<T>.Empty;
    
    public static StoryBoard Vignettes(this int howMany) => StoryBoard.Blank(howMany);

    public static StoryBoard Compose(this StoryBoard from, params Command[] stream)
        => stream.Aggregate(from, (storyboard, command) => command.SketchIn(storyboard));
}