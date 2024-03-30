using FluentAssertions;
using static FunctionalStoryteller.Scenes;
using static FunctionalStoryteller.Specs;
using static FunctionalStoryteller.Storyteller;
using static FunctionalStoryteller.Tests.CharactersToTestsWith;

namespace FunctionalStoryteller.Tests;

public class BeingRejectedTests
{
    [Test, Ignore("Tenemos que arreglar el is in love")]
    public void BecomeUnrequited_IfLoveIsNotMutual()
    {
        OnceUponATime()
            .Happened(Love().Between(Someone, AnybodyElse))
            .Happened(Love().Between(Adam, Someone))
            .Then(Unrequited(Adam)).Should().BeTrue();
    }

    [Test, Ignore("Tenemos que arreglar el is in love")]
    public void fasfafas()
    {
        OnceUponATime()
            .Happened(Love().Between(Someone, AnybodyElse))
            .Happened(Love().Between(Adam, Someone))
            .Then(Someone.Loves(Adam)).Should().BeFalse();
    }

    [Test]
    public void WhenLoveIsMutual_NotUnrequited()
    {
        OnceUponATime()
            .Happened(Love().Between(Adam, Someone))
            .Then(Unrequited(Adam)).Should().BeFalse();
    }
}