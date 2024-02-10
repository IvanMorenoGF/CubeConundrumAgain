using LanguageExt;
using static LanguageExt.Seq<CubeConundrumAgain.Character>;

namespace CubeConundrumAgain;

public sealed class DeathScene : Scene
{
    readonly Character buriedOne;
    readonly Character grievingOne;
    
    public DeathScene() { }

    public DeathScene(Character buriedOne) => this.buriedOne = buriedOne;

    public DeathScene Buried(Character who) => new(who);
    
    protected override Seq<Character> Cast => Empty.Add(buriedOne).Add(grievingOne);
    public bool IsInTheTomb(Character who) => buriedOne == who;
}