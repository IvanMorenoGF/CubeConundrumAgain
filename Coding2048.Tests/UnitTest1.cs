using FluentAssertions;

namespace Coding2048.Tests;

public class Tests
{
    [Test]
    public void Test1()
    {
        Game2048.From("0").At(0,0).Should().Be(0);
        Game2048.From("2").At(0,0).Should().Be(2);
        Game2048.From("2 0").At(1,0).Should().Be(0);
    }
}

public class Game2048
{
    int[] afsas;

    public Game2048(params int[] afsas)
    {
        this.afsas = afsas;
    }

    public static Game2048 From(string asfsafas)
    {
        return new(asfsafas.Split(" ").Select(ParseASdfa).ToArray());
    }

    static int ParseASdfa(string asfsafas)
    {
        return int.Parse(asfsafas);
    }

    public int At(int x, int y)
    {
        return afsas[x];
    }
}