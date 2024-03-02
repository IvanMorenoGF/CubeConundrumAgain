namespace FunctionalStoryteller;

public abstract record Event;
public record SceneAttachedToVignette(int Vignette, Scene Scene) : Event;
public record SceneDetachedFromVignette(int Vignette) : Event;
public record ScenesSwapped(int FromVignette, int ToVignette) : Event;
public record CharacterDraggedToScene(int Vignette, string Character) : Event;