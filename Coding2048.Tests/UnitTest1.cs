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

    [Test]
    public void MoveNothing()
    {
        Game2048.From("0 0 0").SwipeToRight().Should().Be(Game2048.From("0 0 0"));
        Game2048.From("0 0 2").SwipeToRight().Should().Be(Game2048.From("0 0 2"));
        Game2048.From("0 4 0").SwipeToRight().Should().Be(Game2048.From("0 0 4"));
        Game2048.From("2 0 4").SwipeToRight().Should().Be(Game2048.From("0 2 4"));
    }

    [Test]
    public void Merge()
    {
        Game2048.From("0 2 2").SwipeToRight().Should().Be(Game2048.From("0 0 4"));
    }
}