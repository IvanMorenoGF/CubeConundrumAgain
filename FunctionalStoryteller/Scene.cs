using LanguageExt;

namespace FunctionalStoryteller;

public abstract record Scene
{
    public static DeathScene Death() => new();
    public static LoveScene Love() => new();
    public static SolitudeScene Solitude() => new();

    public bool IsInTheCast(Character who) => Cast.Contains(who);
    public bool AreInTheCast(params Character[] who) => who.All(IsInTheCast);
    protected abstract Seq<Character> Cast { get; }
    public abstract Scene PlaceAt(int where, Character who);
    public abstract Character CharacterAt(int from);
    
    [Obsolete("Es temporal hasta que existan slots")]
    protected string NameOf(Character character) => character?.ToString() ?? "nobody";
}