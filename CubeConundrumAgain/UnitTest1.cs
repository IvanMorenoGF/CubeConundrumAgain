using FluentAssertions;

namespace CubeConundrumAgain;

public class Tests
{
    [Test]
    public void Test1()
    {
        Story.ASdfsaf().IsAdanAlive().Should().BeTrue();
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
        return true;
    }
}