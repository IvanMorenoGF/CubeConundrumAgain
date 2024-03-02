using FluentAssertions;
using LanguageExt.UnsafeValueAccess;
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

    [Test]
    public void DragCharacterToSceneEvent()
    {
        DragTo(vignette: 1, where: 1, Adam).sdfsafas().ValueUnsafe().Should()
            .Be(Events.CharacterPlacedInScene(vignette: 1, where: 1, Adam));
        DragTo(vignette: 1, where: 2, Adam).sdfsafas().ValueUnsafe().Should()
            .NotBe(Events.CharacterPlacedInScene(vignette: 1, where: 1, Adam));
    }

    [Test, Ignore("Nos hemos dado cuenta de que los comandos necesitan estado para la generación del evento")]
    public void SwapCharactersEvent()
    {
        
    }
}