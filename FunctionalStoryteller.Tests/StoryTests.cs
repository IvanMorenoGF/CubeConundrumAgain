using FluentAssertions;
using static FunctionalStoryteller.Scenes;
using static FunctionalStoryteller.Storyteller;
using static FunctionalStoryteller.Tests.CharactersToTestsWith;

namespace FunctionalStoryteller.Tests;

public class StoryTests
{
    [Test]
    public void Scenes_InWhich_ACharacterActs()
    {
        OnceUponATime()
            .Happened(Solitude().Of(Adam))
            .Happened(Solitude().Of(Eve))
            .ScenesOf(Adam).Should().HaveCount(1);
        
        OnceUponATime()
            .Happened(Solitude().Of(Adam))
            .Happened(Solitude().Of(Eve))
            .Happened(Love().Between(Adam, Eve))
            .ScenesOf(Adam).Should().HaveCount(2);

        OnceUponATime()
            .Happened(Solitude().Of(Adam))
            .Happened(Solitude().Of(Eve))
            .ScenesOf(Adam).Single().Should().Be(Solitude().Of(Adam));
    }

    [Test]
    public void CastingOfStory()
    {
        OnceUponATime().Casting.Should().BeEmpty();
        OnceUponATime()
            .Happened(Solitude().Of(Adam))
            .Casting.Should().NotBeEmpty();
    }

    [Test]
    public void Casting_OfAStory_ContainsNoDuplicates()
    {
        OnceUponATime()
            .Happened(Solitude().Of(Adam))
            .Happened(Love().Between(Adam, Eve))
            .Casting.Should().HaveCount(2);
    }
}