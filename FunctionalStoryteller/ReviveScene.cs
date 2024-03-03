using LanguageExt;
using LanguageExt.UnsafeValueAccess;

namespace FunctionalStoryteller;

public sealed record ReviveScene : Scene
{
    Option<Character> theRevivedOne;
    public ReviveScene Of(Character who) => new() { theRevivedOne = who };
    public override Seq<Character> Cast => theRevivedOne.Match(Some: who => Seq<Character>.Empty.Add(who), None: Seq<Character>.Empty);

    public override Scene PlaceAt(int where, Character who)
    {
        if (where != 1)
            throw new ArgumentOutOfRangeException(nameof(where));
        
        return Of(who);
    }
    
    public override string ToString() => $"{theRevivedOne.ValueUnsafe().Name()} revived";
}