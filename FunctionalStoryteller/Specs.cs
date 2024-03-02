namespace FunctionalStoryteller;

public static class Specs
{
    public static Spec InTheCast(Character who) => new IsInTheCast(who);
}