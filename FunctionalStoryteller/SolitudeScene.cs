using LanguageExt;
using LanguageExt.UnsafeValueAccess;

namespace FunctionalStoryteller;

public sealed record SolitudeScene : Scene
{
    Option<Character> theOneAlone;
    public SolitudeScene Of(Character who) => new() { theOneAlone = who };
    public override Seq<Character> Cast => theOneAlone.Match(Some: who => Seq<Character>.Empty.Add(who), None: Seq<Character>.Empty);

    public override Scene PlaceAt(int where, Character who)
    {
        if (where != 1)
            throw new ArgumentOutOfRangeException(nameof(where));
        
        return Of(who);
    }
    
    public override string ToString() => $"1️⃣{theOneAlone.ValueUnsafe().Name()}";
}