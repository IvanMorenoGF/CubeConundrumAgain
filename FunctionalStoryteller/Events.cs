namespace FunctionalStoryteller;

public static class Events
{
    public static Event SceneAttachedToVignette(int vignette, Scene where)
    {
        return new SceneAttachedToVignette(vignette, where);
    }
}