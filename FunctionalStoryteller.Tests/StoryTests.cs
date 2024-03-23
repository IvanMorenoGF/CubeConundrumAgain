using FluentAssertions;

namespace FunctionalStoryteller.Tests;

public class StoryTests
{
    [Test]
    public void Scenes_InWhich_ACharacterActs()
    {
        Storyteller.OnceUponATime()
            .Happened(Scenes.Solitude().Of(CharactersToTestsWith.Adam))
            .Happened(Scenes.Solitude().Of(CharactersToTestsWith.Eve))
            .ScenesOf(CharactersToTestsWith.Adam).Should().HaveCount(1);
        
        Storyteller.OnceUponATime()
            .Happened(Scenes.Solitude().Of(CharactersToTestsWith.Adam))
            .Happened(Scenes.Solitude().Of(CharactersToTestsWith.Eve))
            .Happened(Scenes.Love().Between(CharactersToTestsWith.Adam, CharactersToTestsWith.Eve))
            .ScenesOf(CharactersToTestsWith.Adam).Should().HaveCount(2);

        Storyteller.OnceUponATime()
            .Happened(Scenes.Solitude().Of(CharactersToTestsWith.Adam))
            .Happened(Scenes.Solitude().Of(CharactersToTestsWith.Eve))
            .ScenesOf(CharactersToTestsWith.Adam).Single().Should().Be(Scenes.Solitude().Of(CharactersToTestsWith.Adam));
    }
}