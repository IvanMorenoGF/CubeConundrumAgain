using FluentAssertions;
using NUnit.Framework.Internal;

namespace Coding2048.Tests;

public class Tests
{
    [Test]
    public void Test1()
    {
        Game2048.From("0").At(0, 0).Should().Be(0);
        Game2048.From("2").At(0, 0).Should().Be(2);
        Game2048.From("2 0").At(1, 0).Should().Be(0);
        Game2048.From("2 0", "0 0").At(0, 1).Should().Be(0);
        Game2048.From("2 0 8",
                "0 0 4",
                "4 0 16")
            .At(2, 2).Should().Be(16);
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
        Game2048.From("2 2 2").SwipeToRight().Should().Be(Game2048.From("0 2 4"));
        Game2048.From("2 2 2 2").SwipeToRight().Should().Be(Game2048.From("0 0 4 4"));
        Game2048.From("0 4 4 2").SwipeToRight().Should().Be(Game2048.From("0 0 8 2"));
        Game2048.From("4 0 4 2").SwipeToRight().Should().Be(Game2048.From("0 0 8 2"));
        Game2048.From("4 8 4 2").SwipeToRight().Should().Be(Game2048.From("4 8 4 2"));
    }

    [Test]
    public void MergeTwoLines_ToTheRight()
    {
        Game2048.From("0 2 2", 
                      "0 2 2").SwipeToRight().Should().Be(Game2048.From("0 0 4", 
                                                                        "0 0 4"));
    }

    [Test, Ignore("")]
    public void MoveDown()
    {
        Game2048.From("2 0 0", 
                      "0 0 0").SwipeDown().Should().Be(Game2048.From("0 0 0", 
                                                                     "2 0 0"));
    }

    [Test]
    public void RotateGame()
    {
        Game2048.From("2 0 0", 
                      "0 0 0",
                      "0 0 0").RotateToTheRight().Should().Be(Game2048.From("0 0 2", 
                                                                  "0 0 0",
                                                                  "0 0 0"));
    }
    
}