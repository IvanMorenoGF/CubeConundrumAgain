namespace FunctionalStoryteller;

public class AndSpec : Spec
{
    readonly Spec[] specs;

    public AndSpec(Spec[] specs)
    {
        this.specs = specs;
    }
    
    public override bool IsSatisfiedBy(Story story) 
        => specs.All(s => s.IsSatisfiedBy(story));
}