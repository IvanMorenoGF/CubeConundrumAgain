namespace FunctionalStoryteller;

internal class SomebodySpec : Spec
{
    readonly Func<Character, Spec>[] command;

    public SomebodySpec(params Func<Character, Spec>[] command)
    {
        this.command = command;
    }

    public override bool IsSatisfiedBy(Story story)
        => story.Casting
            .Map(c => command.Map(x => x(c)))
            .Map(e => new AndSpec(e.ToArray()))
            .Any(s => s.IsSatisfiedBy(story));
}