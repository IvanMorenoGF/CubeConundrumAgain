using LanguageExt;

namespace FunctionalStoryteller;

public abstract record Scene
{
    public static DeathScene Death() => new();
    public static LoveScene Love() => new();

    public bool IsInTheCast(Character who) => Cast.Contains(who);
    protected abstract Seq<Character> Cast { get; }
}