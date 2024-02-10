using LanguageExt;
using static LanguageExt.Seq<CubeConundrumAgain.Character>;

namespace CubeConundrumAgain;

public sealed class LoveScene : Scene
{
    readonly (Character left, Character right) couple;
    public LoveScene() { }

    public LoveScene(Character left, Character right) => couple = (left, right);

    protected override Seq<Character> Cast => Empty.Add(couple.left).Add(couple.right);

    public LoveScene Between(Character one, Character other) => new(one, other);
    public Character LoverOf(Character lover) => couple.left == lover ? couple.right : couple.left;
}