namespace FunctionalStoryteller;

public static class Events
{
    public static Event SceneAttachedToVignette(int vignette, Scene where)
    {
        return new SceneAttachedToVignette(vignette, where);
    }

    public static Event SceneDetachedFromVignette(int vignette)
    {
        return new SceneDetachedFromVignette(vignette);
    }

    public static Event ScenesSwapped(int fromVignette, int toVignette)
    {
        return new ScenesSwapped(fromVignette, toVignette);
    }
}