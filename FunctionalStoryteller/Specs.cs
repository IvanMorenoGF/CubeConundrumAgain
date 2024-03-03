namespace FunctionalStoryteller;

public static class Specs
{
    public static Spec InTheCast(Character who) => new IsInTheCast(who);
    public static Spec Alive(Character who) => new IsAlive(who);
    public static Spec InLoveWith(Character who, Character whom) => new IsInLoveWith(who, whom);
    public static Spec KnowableOfLove(Character who) => new IsKnowableOfLove(who);
    public static Spec Not(Spec spec) => new NotSpec(spec);
}