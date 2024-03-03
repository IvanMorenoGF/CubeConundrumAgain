namespace FunctionalStoryteller;

public class NotSpec : Spec
{
    readonly Spec spec;
    public NotSpec(Spec spec) => this.spec = spec;

    public override bool IsSatisfiedBy(Story story) => !spec.IsSatisfiedBy(story);
}