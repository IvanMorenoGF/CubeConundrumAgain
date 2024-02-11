using LanguageExt;

namespace FunctionalStoryteller;

internal static class Scriptwriter
{
    public static bool PartOfAny<T>(this Story story, Character who) where T : Scene
        => story.scenes.OfType<T>().Any(x => x.IsInTheCast(who));
    
    public static Option<T> First<T>(this Story story, Character of) where T : Scene
        => story.PartOfAny<T>(of)
            ? story.scenes.OfType<T>().First(x => x.IsInTheCast(of))
            : Option<T>.None;
}