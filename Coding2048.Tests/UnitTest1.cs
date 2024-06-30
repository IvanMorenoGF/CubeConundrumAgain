using FluentAssertions;
using NUnit.Framework.Internal;

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
        Game2048.From("2 0 8", 
                      "0 0 4",
                      "4 0 16")
            .At(2,2).Should().Be(16);
    }
}

public class Game2048
{
    List<int[]> allLines;

    public Game2048(List<int[]> allLines)
    {
        if (HaveSameWidth(allLines) != 1)
            throw new ArgumentException("Todas las filas no tienen el mismo ancho");
        if (allLines.SelectMany(x => x).Any(x => !IsPowerOf2(x)))
            throw new ArgumentException("No todos los números son parte del juego");
        
        this.allLines = allLines;
    }

    static int HaveSameWidth(List<int[]> allLines) => allLines.Select(x => x.Length).Distinct().Count();
    static bool IsPowerOf2(int aNumber) => aNumber != 1 && (aNumber & (aNumber - 1)) == 0;

    public static Game2048 From(params string[] allLines) => new(allLines.Select(ParseLine).ToList());

    static int[] ParseLine(string line) => line.Split(" ").Select(Parse).ToArray();
    static int Parse(string number) => int.Parse(number);
    public int At(int x, int y)
    {
        return allLines[y][x];
    }
}