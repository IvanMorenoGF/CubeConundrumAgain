namespace FunctionalStoryteller;

public static class Command
{
    public static DragSceneToVignette DragTo(int vignette, Scene scene) => new(vignette, scene);
}