using FluentAssertions;
using static FunctionalStoryteller.Scenes;
using static FunctionalStoryteller.Specs;
using static FunctionalStoryteller.Storyteller;
using static FunctionalStoryteller.Tests.CharactersToTestsWith;
namespace FunctionalStoryteller.Tests;

public class SAfasfasaf
{
    [Test]
    public void IsKnowableOfLove()
    {
        OnceUponATime()
            .Happened(Love().Between(Adam, Eve))
            .Then(Single(Adam)).Should().BeTrue();
    }

    [Test]
    public void NeverWas_KnowableOfLove()
    {
        OnceUponATime()
            .Happened(Death().Of(Eve).WatchedBy(Adam))
            .Then(Single(Adam)).Should().BeFalse();
    }
    
    [Test]
    public void WasKnowableOfLove_ButNotNow()
    {
        OnceUponATime()
            .Happened(Love().Between(Adam,Eve))
            .Happened(Death().Of(Eve).WatchedBy(Adam))
            .Then(Single(Adam)).Should().BeFalse();
    }
}