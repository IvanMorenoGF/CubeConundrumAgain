using FluentAssertions;

namespace CubeConundrumAgain;

public class Tests
{
    [Test]
    public void Test1()
    {
        Game.safasas(1, new(1231,12312,123131))
            .Handful(1, 23, 3)
            .Handful(2, 123, 323)
            .IsPossible.Should().BeTrue();
        
        Game.safasas(1, new(0, 0, 0))
            .Handful(1, 0, 0)
            .IsPossible.Should().BeFalse();

        Game.safasas(1, new(1, 1, 1))
            .Handful(1, 1, 1)
            .IsPossible.Should().BeTrue();
    }

    [Test]
    public void afsadf()
    {
        Asfasfs.NewOne().Result().Should().Be(0);
    }
}

public class Asfasfs
{
    public static Asfasfs NewOne()
    {
        return new();
    }

    public int Result()
    {
        return 0;
    }
}

internal struct Bag
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
    
    internal bool FitsIn(Bag other) => r <= other.r && g <= other.g && b <= other.b;
    internal bool CanFit(Bag other) => other.FitsIn(this);
}

public class Game
{
    private Bag bag;
    private List<Bag> handfuls = new();
    int id;

    internal Game(int id, Bag bag)
    {
        this.id = id;
        this.bag = bag;
    }

    internal static Game safasas(int id, Bag whereStore)
    {
        return new Game(id, whereStore);
    }

    public Game Handful(int r, int g, int b)
    {
        handfuls.Add(new(r, g, b));
        return this;
    }

    public bool IsPossible => handfuls.All(bag.CanFit);
}