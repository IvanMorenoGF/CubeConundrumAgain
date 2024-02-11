using LanguageExt;
using static LanguageExt.Seq<FunctionalStoryteller.Character>;

namespace FunctionalStoryteller;

public sealed class LoveScene : Scene
{
    readonly (Character left, Character right) couple;

    protected override Seq<Character> Cast => Empty.Add(couple.left).Add(couple.right);
    
    public LoveScene() { }

    public LoveScene(Character left, Character right) => couple = (left, right);

    public LoveScene With(Character atLeft = null, Character atRight = null)
        => Between(atLeft ?? couple.left, atRight ?? couple.right);
    public LoveScene Between(Character one, Character other) => new(one, other);
    public Character LoverOf(Character lover) => couple.left == lover ? couple.right : couple.left;
}