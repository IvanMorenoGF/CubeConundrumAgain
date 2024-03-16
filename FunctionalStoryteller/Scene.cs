using LanguageExt;

namespace FunctionalStoryteller;

public abstract record Scene
{
    public bool IsInTheCast(Option<Character> who)
        => who.Match
        (
            Some: someone => Cast.Contains(someone),
            None: false
        );

    public bool AreInTheCast(params Character[] who) => who.All(x => IsInTheCast(x));

    public Character CharacterAt(int index)
    {
        if (index < 1 || index > Cast.Count) throw new ArgumentOutOfRangeException(nameof(index));
        return Cast[index - 1];
    }

    public abstract Seq<Character> Cast { get; }
    public abstract Scene PlaceAt(int where, Character who);
}