using FluentAssertions;

namespace Coding2048.Tests;

public class Tests
{
    [Test]
    public void Test1()
    {
        Game2048.From("0").At(0,0).Should().Be(0);
    }
}

public class Game2048
{
    public static Game2048 From(string asfsafas)
    {
        return new();
    }

    public int At(int x, int y)
    {
        return 0;
    }
}