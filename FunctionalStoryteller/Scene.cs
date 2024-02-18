using LanguageExt;

namespace FunctionalStoryteller;

public abstract record Scene
{
    public bool IsInTheCast(Character who) => Cast.Contains(who);
    public bool AreInTheCast(params Character[] who) => who.All(IsInTheCast);
    public Character CharacterAt(int index)
    {
        if (index < 1 || index > Cast.Count) throw new ArgumentOutOfRangeException(nameof(index));
        return Cast[index - 1];
    }

    protected abstract Seq<Character> Cast { get; }
    public abstract Scene PlaceAt(int where, Character who);
}