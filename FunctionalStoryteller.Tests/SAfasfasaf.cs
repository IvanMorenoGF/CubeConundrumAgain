using FluentAssertions;
using static FunctionalStoryteller.Scenes;
using static FunctionalStoryteller.Specs;
using static FunctionalStoryteller.Storyteller;
using static FunctionalStoryteller.Tests.CharactersToTestsWith;
namespace FunctionalStoryteller.Tests;

public class SAfasfasaf
{
    [Test]
    public void NotSingle()
    {
        OnceUponATime()
            .Happened(Love().Between(Adam, Eve))
            .Then(Single(Adam)).Should().BeFalse();
    }
}