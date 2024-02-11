using LanguageExt;
using static LanguageExt.Seq<FunctionalStoryteller.Character>;

namespace FunctionalStoryteller;

public sealed record DeathScene : Scene
{
    readonly Character buriedOne;
    readonly Character grievingOne;
    
    protected override Seq<Character> Cast => Empty.Add(buriedOne).Add(grievingOne);

    public DeathScene() { }

    public DeathScene(Character buriedOne, Character grievingOne)
    {
        this.buriedOne = buriedOne;
        this.grievingOne = grievingOne;
    }

    public DeathScene Of(Character who) => new(who, grievingOne);
    public DeathScene WatchedBy(Character who) => new(buriedOne, who);

    public bool IsInTheTomb(Character who) => buriedOne == who;
}