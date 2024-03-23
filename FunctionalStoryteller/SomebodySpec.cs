namespace FunctionalStoryteller;

internal class SomebodySpec : Spec
{
    readonly Func<Character, Spec> command;

    public SomebodySpec(Func<Character,Spec> command)
    {
        this.command = command;
    }

    public override bool IsSatisfiedBy(Story story)
    {
        return story.Casting.All(c => command(c).IsSatisfiedBy(story));
    }
}