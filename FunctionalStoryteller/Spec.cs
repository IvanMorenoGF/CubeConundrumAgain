namespace FunctionalStoryteller;

public abstract class Spec
{
    public abstract bool SatisfiedBy(Story wherein);

    public static Spec Dead(Character who) => new OfSomeone(who, (s, c) => !s.IsAlive(c));
    public static Spec Alive(Character who) => new OfSomeone(who, new Alive().Is);
    public static Spec Loved(Character who) => new OfSomeone(who, (s, c) => s.WhoLoves(c).IsSome);
    public static Spec Heartbroken(Character who) => new OfSomeone(who, (s, c) => s.IsHeartbroken(c));
}

internal sealed class OfSomeone : Spec
{
    readonly Character who;
    readonly Func<Story, Character, bool> predicate;

    public OfSomeone(Character who, Func<Story, Character, bool> predicate)
    {
        this.who = who;
        this.predicate = predicate;
    }
    
    public override bool SatisfiedBy(Story wherein) => predicate(wherein, who);
}

public sealed class Composite : Spec
{
    readonly Spec[] specs;
    public Composite(params Spec[] specs) => this.specs = specs;
    
    public override bool SatisfiedBy(Story wherein) => specs.All(s => s.SatisfiedBy(wherein));
}