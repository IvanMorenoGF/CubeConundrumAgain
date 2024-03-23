using FluentAssertions;
using static FunctionalStoryteller.Scenes;
using static FunctionalStoryteller.Specs;
using static FunctionalStoryteller.Storyteller;
using static FunctionalStoryteller.Tests.CharactersToTestsWith;

namespace FunctionalStoryteller.Tests;

[Ignore("")]
public class Defects
{
    [Test, Description("Necesitamos temporalidad para esta spec")]
    public void YouCanBeScared_BeforeSeeingAGhost()
    {
        OnceUponATime()
            .Happened(Love().Between(Adam, Eve))
            .Happened(Death().Of(Adam))
            .Then(Scared(Eve))
            .Should().BeFalse("No deberías poder predecir la muerte de alguien");
    }
    
    [Test, Description("Sólo comprobamos la primera historia de amor")]
    public void YouCannot_FallInLoveAgain()
    {
        OnceUponATime()
            .Happened(Love().Between(Adam, Eve))
            .Happened(Death().Of(Adam).WatchedBy(Eve))
            .Happened(Love().Between(AnybodyElse, Eve))
            .Then(Heartbroken(Eve)).Should().BeFalse();
    }
    
    [Test, Description("Nos hemos dado cuenta de que los comandos necesitan estado para la generación del evento")]
    public void SwapCharactersEvent()
    {
        Assert.Fail();
    }
}