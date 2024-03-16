namespace FunctionalStoryteller;

public class WasSpec : Spec
{
    readonly Spec spec;
    public WasSpec(Spec spec) => this.spec = spec;

    public override bool IsSatisfiedBy(Story story) => story.asfsafasf().SkipLast().Any(spec.IsSatisfiedBy);
}