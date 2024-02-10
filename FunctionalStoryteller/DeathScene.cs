﻿using LanguageExt;
using static LanguageExt.Seq<CubeConundrumAgain.Character>;

namespace CubeConundrumAgain;

public sealed class DeathScene : Scene
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

    public DeathScene Buried(Character who) => new(who, grievingOne);
    public DeathScene Grieving(Character who) => new(buriedOne, who);

    public bool IsInTheTomb(Character who) => buriedOne == who;
}