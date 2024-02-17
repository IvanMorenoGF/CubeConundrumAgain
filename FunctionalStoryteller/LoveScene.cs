using LanguageExt;
using static LanguageExt.Seq<FunctionalStoryteller.Character>;

namespace FunctionalStoryteller;

public sealed record LoveScene : Scene
{
    readonly (Character left, Character right) couple;

    protected override Seq<Character> Cast => Empty.Add(couple.left).Add(couple.right);

    public LoveScene()
    {
    }

    public LoveScene(Character left, Character right) => couple = (left, right);

    public LoveScene Between(Character one, Character other) => new(one, other);

    public Character LoverOf(Character who) => couple.left == who ? couple.right : couple.left;

    public Option<Character> PotentialLoverOf(Character who)
        => !IsInTheCast(who)
            ? Option<Character>.None
            : couple.left == who
                ? couple.right
                : couple.left;

    public override Scene PlaceAt(int where, Character who)
        => where switch
        {
            1 => Between(who, couple.right),
            2 => Between(couple.left, who),
            _ => throw new ArgumentOutOfRangeException(nameof(where))
        };
}