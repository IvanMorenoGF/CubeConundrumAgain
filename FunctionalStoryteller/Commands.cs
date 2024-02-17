namespace FunctionalStoryteller;

public static class Commands
{
    public static DragSceneToVignette DragTo(int vignette, Scene scene) => new(vignette, scene);
    public static DragFromOtherVignette Drag(int fromVignette, int toVignette) => new(fromVignette, toVignette);
}