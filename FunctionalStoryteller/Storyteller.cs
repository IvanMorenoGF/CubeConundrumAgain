using LanguageExt;

namespace FunctionalStoryteller;

public static class Storyteller
{
    public static Story OnceUponATime() => new(Seq<Scene>.Empty);
    public static Story Happened(this Story where, Scene what) => new(where.scenes.Add(what));
}