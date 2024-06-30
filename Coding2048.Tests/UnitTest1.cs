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

        CanMerge(new int[] { 2, 2 }).Should().BeTrue();
        CanMerge(new int[] { 2, 1 }).Should().BeFalse();
        MergeTwo(new int[] { 2, 2 }).Should().BeEquivalentTo(new int[] { 0, 4 });
        MergeTwo(new int[] { 2, 4 }).Should().BeEquivalentTo(new int[] { 2, 4 });
        MergeMore(new int[] { 2, 2, 2 }).Should().BeEquivalentTo(new int[] { 0, 2, 4 });
    }
    
    int[] MergeMore(int[] ints)
    {
        return CanMerge(ints) ? new int[] { 0, ints[1], ints[0] * 2 } : ints;
    }

    int[] MergeTwo(int[] ints)
    {
        if(ints.Length != 2)
            throw new ArgumentException();
        
        return CanMerge(ints) ? new int[] { 0, ints.First() * 2 } : ints;
    }

    bool CanMerge(int[] ints)
    {
        return ints.Last() == ints.First();
    }
}