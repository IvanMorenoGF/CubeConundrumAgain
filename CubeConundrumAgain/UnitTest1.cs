using FluentAssertions;

namespace CubeConundrumAgain;

public class Tests
{
    [Test]
    public void Test1()
    {
        Game.safasas("1", new(1231,12312,123131))
            .Handful(1, 23, 3)
            .Handful(2, 123, 323)
            .IsPossible.Should().BeTrue();
        
        Game.safasas("1", new(0, 0, 0))
            .Handful(1, 0, 0)
            .IsPossible.Should().BeFalse();

        Game.safasas("1", new(1, 1, 1))
            .Handful(1, 1, 1)
            .IsPossible.Should().BeTrue();
    }
}

public struct Bag
{
    public readonly int r;
    public readonly int g;
    public readonly int b;

    public Bag(int r, int g, int b)
    {
        this.r = r;
        this.g = g;
        this.b = b;
    }
}

public class Game
{
    private Bag bag;
    private List<(int r, int g, int b)> handfuls = new();

    public Game(string id, Bag bag)
    {
        this.bag = bag;
    }

    public static Game safasas(string s, Bag whereStore)
    {
        return new Game(s, whereStore);
    }

    public Game Handful(int i, int i1, int i2)
    {
        handfuls.Add((i, i1, i2));
        return this;
    }

    public bool IsPossible => handfuls.All(h => h.r <= bag.r && h.g <= bag.g && h.b <= bag.b);
}