namespace FunctionalStoryteller;

public static class Events
{
    public static Event SceneAttachedToVignette(int vignette, DeathScene death)
    {
        return new();
    }
}