using FluentAssertions;

namespace CubeConundrumAgain;

public class Tests
{
    [Test]
    public void Test1()
    {
        Story.ASdfsaf().IsAdanAlive().Should().BeTrue();
        Story.ASdfsaf().IsEvaAlive().Should().BeTrue();
        Story.ASdfsaf().IsAlive("Adan").Should().BeTrue();
    }
}

public class Story
{
    public static Story ASdfsaf()
    {
        return new();
    }

    public bool IsAdanAlive()
    {
        return IsAlive("Adan");
    }

    public bool IsEvaAlive()
    {
        return IsAlive("Eva");
    }

    public bool IsAlive(string who)
    {
        return true;
    }
}