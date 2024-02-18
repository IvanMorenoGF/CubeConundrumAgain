using LanguageExt;
using static LanguageExt.Seq<FunctionalStoryteller.Character>;

namespace FunctionalStoryteller;

public sealed record DeathScene : Scene
{
    readonly Character grievingOne;
    readonly Character buriedOne;

    protected override Seq<Character> Cast => Empty.Add(grievingOne).Add(buriedOne);

    public DeathScene()
    {
    }

    public DeathScene(Character buriedOne, Character grievingOne)
    {
        this.buriedOne = buriedOne;
        this.grievingOne = grievingOne;
    }

    public DeathScene Of(Character who) => new(who, grievingOne);

    public DeathScene WatchedBy(Character who)
    {
        if (who is null) return new DeathScene(buriedOne, null);

        return new DeathScene(who.Equals(buriedOne) ? null : buriedOne, who);
    }

    public bool IsInTheTomb(Character who) => buriedOne == who;

    public override Scene PlaceAt(int where, Character who)
        => where switch
        {
            1 => WatchedBy(who),
            2 => Of(who),
            _ => throw new ArgumentOutOfRangeException(nameof(where))
        };

    public override string ToString() => $"👁️{NameOf(grievingOne)} ☠️{NameOf(buriedOne)}";
}