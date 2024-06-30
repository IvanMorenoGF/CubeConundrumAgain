namespace Coding2048.Tests;

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

    public Game2048 SwipeToRight()
    {
        return new(allLines.Select(SwipeLineToRight).ToList());
    }

    int[] SwipeLineToRight(int[] arg)
    {
        var withoutZeroes = arg.Where(x => x != 0).ToArray();
        var zeroes = arg.Length - withoutZeroes.Length;
        var result = new int[arg.Length];
        Merge(withoutZeroes, result, zeroes);

        return result;
    }

    static void Merge(int[] withoutZeroes, int[] result, int zeroes)
    {
        for (int i = 0; i < withoutZeroes.Length; i++)
        {
            if (i + 1 < withoutZeroes.Length && withoutZeroes[i] == withoutZeroes[i + 1])
            {
                i++;
                result[zeroes + i] = withoutZeroes[i] * 2;
            }
            else
                result[zeroes + i] = withoutZeroes[i];
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Game2048 other)
            return false;

        return ToString() == other.ToString();
    }

    public override string ToString()
    {
        return string.Join("\n", allLines.Select(x => string.Join(" ", x)));
    }
}