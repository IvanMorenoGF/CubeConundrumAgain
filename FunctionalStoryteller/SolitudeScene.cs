using LanguageExt;

namespace FunctionalStoryteller;

public sealed record SolitudeScene : Scene
{
    Option<Character> theOneAlone;
    public SolitudeScene Of(Character who) => new() { theOneAlone = who };
    protected override Seq<Character> Cast => theOneAlone.Match(Some: who => Seq<Character>.Empty.Add(who), None: Seq<Character>.Empty);

    public Scene Esdfadfas(int where, Character who)
    {
        if (where != 1)
            throw new ArgumentOutOfRangeException(nameof(where));
        
        return Of(who);
    }
}