using FluentAssertions;
using LanguageExt.UnsafeValueAccess;
using static FunctionalStoryteller.Commands;
using static FunctionalStoryteller.Events;
using static FunctionalStoryteller.Scenes;

namespace FunctionalStoryteller.Tests;

public class VignetteEventsTests
{
    [Test]
    public void Generate_SceneAttachedToVignetteEvent()
    {
        DragTo(vignette: 1, Death())
            .sdfsafas().ValueUnsafe().Should().Be(SceneAttachedToVignette(vignette: 1, Death()));

        DragTo(vignette: 2, Death())
            .sdfsafas().ValueUnsafe().Should().NotBe(SceneAttachedToVignette(vignette: 1, Death()));

        DragTo(vignette: 3, Love())
            .sdfsafas().ValueUnsafe().Should().Be(SceneAttachedToVignette(vignette: 3, Love()));
    }

    [Test]
    public void Generate_SceneDetachedFromVignetteEvent()
    {
        DragOut(vignette: 1).sdfsafas().ValueUnsafe().Should().Be(SceneDetachedFromVignette(vignette: 1));
        DragOut(vignette: 3).sdfsafas().ValueUnsafe().Should().Be(SceneDetachedFromVignette(vignette: 3));
    }

    [Test]
    public void ScenesSwappedEvent()
    {
        Drag(fromVignette: 1, toVignette: 2).sdfsafas().ValueUnsafe().Should().Be(ScenesSwapped(fromVignette: 1, toVignette: 2));
        Drag(fromVignette: 1, toVignette: 3).sdfsafas().ValueUnsafe().Should().Be(ScenesSwapped(fromVignette: 1, toVignette: 3));
    }
}