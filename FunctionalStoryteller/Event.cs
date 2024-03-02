namespace FunctionalStoryteller;

public abstract record Event;
public record SceneAttachedToVignette(int Vignette, Scene Scene) : Event;
public record SceneDetachedFromVignette(int Vignette) : Event;