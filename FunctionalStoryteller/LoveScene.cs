using LanguageExt;
using static LanguageExt.Seq<FunctionalStoryteller.Character>;

namespace FunctionalStoryteller;

public sealed record LoveScene : Scene
{
    (Character left, Character right) Couple { get; init; }

    protected override Seq<Character> Cast => Empty.Add(Couple.left).Add(Couple.right);

    public LoveScene Between(Character one, Character other) => new() { Couple = (one, other) };

    public Character LoverOf(Character who) => Couple.left == who ? Couple.right : Couple.left;

    public Option<Character> PotentialLoverOf(Character who)
        => !IsInTheCast(who)
            ? Option<Character>.None
            : Couple.left == who
                ? Couple.right
                : Couple.left;

    public override Scene PlaceAt(int where, Character who)
        => where switch
        {
            1 => Between(who, IsInTheCast(who) ? null : Couple.right),
            2 => Between(IsInTheCast(who) ? null : Couple.left, who),
            _ => throw new ArgumentOutOfRangeException(nameof(where))
        };
    
    public override string ToString() => $"{Couple.left.Name()} ❤️ {Couple.right.Name()}";
}