using FluentAssertions;
using static FunctionalStoryteller.Commands;
using static FunctionalStoryteller.Events;
using static FunctionalStoryteller.Scenes;

namespace FunctionalStoryteller.Tests;

public class EventTests
{
    [Test]
    public void Generate_SceneAttachedToVignetteEvent()
    {
        DragTo(vignette:1, Death())
            .sdfsafas().Should().Be(SceneAttachedToVignette(vignette:1, Death()));
        
        DragTo(vignette:2, Death())
            .sdfsafas().Should().NotBe(SceneAttachedToVignette(vignette:1, Death()));
        
        DragTo(vignette:3, Love())
            .sdfsafas().Should().Be(SceneAttachedToVignette(vignette:3, Love()));
    }
    
    [Test]
    public void Generate_SceneDetachedFromVignetteEvent()
    {
        DragOut(vignette:1).sdfsafas().Should().Be(SceneDetachedFromVignette(vignette:1));
        DragOut(vignette:3).sdfsafas().Should().Be(SceneDetachedFromVignette(vignette:3));
    }
}