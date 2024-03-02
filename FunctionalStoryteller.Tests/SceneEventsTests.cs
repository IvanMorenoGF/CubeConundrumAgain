using FluentAssertions;

namespace FunctionalStoryteller.Tests;

public class SceneEventsTests
{
    [Test]
    public void DragCharacterToSceneEvent()
    {
        Commands.DragTo(vignette: 1, CharactersToTestsWith.Adam).sdfsafas().Should().Be(Events.CharacterDraggedToScene(vignette: 1, CharactersToTestsWith.Adam));
        Commands.DragTo(vignette: 2, CharactersToTestsWith.Eva).sdfsafas().Should().NotBe(Events.CharacterDraggedToScene(vignette: 1, CharactersToTestsWith.Adam));
    }
}