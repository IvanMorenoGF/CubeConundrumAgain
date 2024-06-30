using FluentAssertions;

namespace Coding2048.Tests;

public class Tests
{
    [Test]
    public void Test1()
    {
        Game2048.From("0").At(0,0).Should().Be(0);
        Game2048.From("2").At(0,0).Should().Be(2);
    }
}

public class Game2048
{
    int afsas;

    public Game2048(int afsas)
    {
        this.afsas = afsas;
    }

    public static Game2048 From(string asfsafas)
    {
        return new(int.Parse(asfsafas));
    }

    public int At(int x, int y)
    {
        return afsas;
    }
}