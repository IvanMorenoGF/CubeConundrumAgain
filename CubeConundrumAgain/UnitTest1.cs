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
        
        Game.safasas("1", 0, 0, 0)
            .Handful(1, 0, 0)
            .IsPossible.Should().BeFalse();
    }
}

public class Game
{
    private (int r, int g, int b) bag;
    private List<(int r, int g, int b)> handfuls = new();

    public Game(string id, (int r, int g, int b) bag)
    {
        this.bag = bag;
    }

    public static Game safasas(string s, int i, int i1, int i2)
    {
        return new Game(s, (i, i1, i2));
    }

    public Game Handful(int i, int i1, int i2)
    {
        handfuls.Add((i, i1, i2));
        return this;
    }

    public bool IsPossible => handfuls.All(h => h.r <= bag.r && h.g <= bag.g && h.b <= bag.b);
}