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
        var merge = Merge(withoutZeroes);
        var mergeWithoutZeroes = merge.Where(x => x != 0).ToArray();
        var mergeZeroes = merge.Length - mergeWithoutZeroes.Length;
        return PadZeroesToLeft(mergeWithoutZeroes, zeroes + mergeZeroes);
    }

    static int[] PadZeroesToLeft(int[] withoutZeroes, int zeroes)
    {
        return new int[zeroes].Concat(withoutZeroes).ToArray() ;
    }

    static int[] Merge(int[] ints)
    {
        var result = ints.ToArray();

        for (int i = result.Length - 1; i > 0; i--)
        {
            if (!CanMerge(new int[] { result[i - 1], result[i] })) continue;
            result[i] *= 2;
            result[i - 1] = 0;
        }
        
        return result;
    }

    static bool CanMerge(int[] ints)
    {
        return ints.Last() == ints.First();
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

    public Game2048 SwipeDown()
    {
        return this.RotateToTheRight().SwipeToRight().RotateToTheRight().RotateToTheRight().RotateToTheRight();
    }

    public Game2048 RotateToTheRight()
    {
        var newAllLines = new List<int[]>();
        
        for (int i = 0; i < allLines[0].Length; i++)
        {
            newAllLines.Add(allLines.Select(x => x[i]).Reverse().ToArray());
        }
        
        return new Game2048(newAllLines);
    }
}