namespace FunctionalStoryteller;

public static class Commands
{
    public static DragSceneToVignette DragTo(int vignette, Scene scene) => new(vignette, scene);
    public static DragFromOtherVignette Drag(int fromVignette, int toVignette) => new(fromVignette, toVignette);
    public static DragOut DragOut(int vignette) => new(vignette);
    
    public static DragCharacterToVignette DragTo(int vignette, Character who) => new(vignette, who);
    public static DragCharacterToScene DragTo(int vignette,int where, Character who) => new(vignette,where, who);
}