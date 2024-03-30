namespace FunctionalStoryteller;

public static class Specs
{
    public static Spec InTheCast(Character who) => new IsInTheCast(who);
    public static Spec Alive(Character who) => new IsAlive(who);

    public static Spec Loves(this Character who, Character whom) => new IsInLoveWith(who, whom);
    public static Spec KnowableOfLove(Character who) => new IsKnowledgestOfLove(who);
    public static Spec Single(Character who) => new IsKnowledgestOfLove(who);
    public static Spec Heartbroken(Character who) => new IsHeartbroken(who);
    public static Spec Unrequited(Character who) => new IsUnrequited(who);
    
    public static Spec Scared(Character who) => new IsScared(who);
    public static Spec Not(Spec spec) => new NotSpec(spec);
    public static Func<Character,Spec> Not(Func<Character, Spec> x) => c => Not(x(c));
    public static Func<Character,Spec> Was(Func<Character, Spec> alive) => c => Was(alive(c));
    public static Spec Was(Spec spec) => new WasSpec(spec);
    public static Spec Somebody(params Func<Character, Spec>[] x) => new SomebodySpec(x);
}