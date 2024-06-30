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
        Game2048.From("2 0", "0 0").At(0,1).Should().Be(0);
    }
}

public class Game2048
{
    List<int[]> afsas;

    public Game2048(List<int[]> afsas)
    {
        if (HaveSameWidth(afsas) != 1)
            throw new ArgumentException("Todas las filas no tienen el mismo ancho");
        
        this.afsas = afsas;
    }

    static int HaveSameWidth(List<int[]> afsas) => afsas.Select(x => x.Length).Distinct().Count();
    

    public static Game2048 From(params string[] asfsafas)
    {
        return new(asfsafas.Select(ParseLine).ToList());
    }

    static int[] ParseLine(string asfsafas)
    {
        return asfsafas.Split(" ").Select(ParseASdfa).ToArray();
    }

    static int ParseASdfa(string asfsafas)
    {
        return int.Parse(asfsafas);
    }

    public int At(int x, int y)
    {
        return afsas[y][x];
    }
}