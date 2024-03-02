namespace FunctionalStoryteller;

public abstract record Event;
public record SceneAttachedToVignette(int Vignette, Scene Scene) : Event;