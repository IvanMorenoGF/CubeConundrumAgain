namespace CubeConundrumAgain;

public class Scene
{
    readonly string buriedOne;
    readonly (string adan, string eva) couple = ("Adan", "Eva");

    public Scene(string buriedOne) => this.buriedOne = buriedOne;

    public Scene(string adan, string eva) => couple = (adan, eva);

    public static Scene Death()
    {
        return new("");
    }

    public Scene Buried(string who)
    {
        return new(who);
    }

    public bool IsInTheTomb(string who)
    {
        return buriedOne == who;
    }

    public static Scene Love()
    {
        return new("");
    }

    public Scene Between(string adan, string eva)
    {
        return new(adan, eva);
    }
    
    public bool Loves(string adan, string eva) => (adan, eva) == couple || (eva, adan) == couple;
}