using FluentAssertions;
using static FunctionalStoryteller.Commands;
using static FunctionalStoryteller.Tests.CharactersToTestsWith;

namespace FunctionalStoryteller.Tests;

public class SceneEventsTests
{
    [Test]
    public void DragCharacterToVignette_DoesNotGenerateEvent()
    {
        DragTo(vignette: 1, Adam).sdfsafas().IsNone.Should().BeTrue();
    }
}