using FluentAssertions;

namespace CubeConundrumAgain;

public class Tests
{
    [Test]
    public void Test1()
    {
        Game.safasas("1", 1231,12312,123131)
            .Handful(1, 23, 3)
            .Handful(2, 123, 323)
            .IsPossible.Should().BeTrue();
    }
}

public class Game
{

    public static Game safasas(string s, int i, int i1, int i2)
    {
        throw new NotImplementedException();
    }

    public Game Handful(int i, int i1, int i2)
    {
        throw new NotImplementedException();
    }

    public bool IsPossible => true;
}