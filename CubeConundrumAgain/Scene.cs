namespace CubeConundrumAgain;

public class Scene
{
    readonly string buriedOne;
    readonly (Character theOne, Character theOther) couple = ("Adan", "Eva");
    private readonly string sceneId;

    public Scene(Character buriedOne)
    {
        this.buriedOne = buriedOne;
        this.sceneId = "Death";
    }

    public Scene(Character adan, Character eva)
    {
        couple = (theOne: adan, theOther: eva);
        this.sceneId = "Love";
    }

    public static Scene Death() => new("");
    public static Scene Love() => new("");

    public Scene Buried(Character who) => new(who);
    public bool IsInTheTomb(Character who) => buriedOne == who;

    public Scene Between(Character one, Character other) => new(one, other);

    public bool IsLoveScene => sceneId == "Love";
    public bool IsDeathScene => sceneId == "Death";

    public string LoverOf(Character lover) => couple.theOne == lover ? couple.theOther : couple.theOne;
    public bool AreCoupled(Character one, Character other) => IsInTheCast(one) && IsInTheCast(other) && IsLoveScene;
    public bool IsInTheCast(Character who) => who == couple.theOne || who == couple.theOther;
}