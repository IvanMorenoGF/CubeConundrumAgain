namespace FunctionalStoryteller;

public static class Corrector
{
    public static Func<DeathScene, bool> IsInTheTomb(this Character who) => scene => scene.IsInTheTomb(who);
    public static Func<Scene, bool> IsInTheCast(this Character who) => scene => scene.IsInTheCast(who);
}