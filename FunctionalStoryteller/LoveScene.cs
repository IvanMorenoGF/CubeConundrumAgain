﻿using LanguageExt;
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
            1 => Between(who, Couple.right),
            2 => Between(Couple.left, who),
            _ => throw new ArgumentOutOfRangeException(nameof(where))
        };
    
    public override Character CharacterAt(int from)
        => from switch
        {
            1 => Couple.left,
            2 => Couple.right,
            _ => throw new ArgumentOutOfRangeException(nameof(from))
        };
    
    public override string ToString() => $"{NameOf(Couple.left)} ❤️ {NameOf(Couple.right)}";
}