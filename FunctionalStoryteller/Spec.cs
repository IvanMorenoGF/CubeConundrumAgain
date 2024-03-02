namespace FunctionalStoryteller;

public static class Specs
{
    public static Spec Alive(Character who) => new AliveSpec(who);
}

public class AliveSpec : Spec
{
    public AliveSpec(Character who)
    {
    }
}

public abstract class Spec
{
    public bool IsSatisfiedBy(Story story) => true;
}