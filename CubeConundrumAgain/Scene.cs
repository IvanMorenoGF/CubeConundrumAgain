namespace CubeConundrumAgain;

public class Scene
{
    readonly string buriedOne;
    readonly (string theOne, string theOther) couple = ("Adan", "Eva");
    private readonly string sceneId;

    public Scene(string buriedOne)
    {
        this.buriedOne = buriedOne;
        this.sceneId = "Death";
    }

    public Scene(string adan, string eva)
    {
        couple = (theOne: adan, theOther: eva);
        this.sceneId = "Love";
    }

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
    
    public bool IsLoveScene => sceneId == "Love";
    public bool IsDeathScene => sceneId == "Death";

    public string LoverOf(string lover) => couple.theOne == lover ? couple.theOther : couple.theOne;
    public bool AreCoupled(string one, string other) => IsInTheCast(one) && IsInTheCast(other) && IsLoveScene;
    public bool IsInTheCast(string who) => who == couple.theOne || who == couple.theOther;
}