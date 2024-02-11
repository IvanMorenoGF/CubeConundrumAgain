using FluentAssertions;
using static FunctionalStoryteller.Scene;
using static FunctionalStoryteller.Storyteller;

namespace FunctionalStoryteller.Tests;

public class MiscTests
{
    [Test]
    public void IsInTheCast()
    {
        Love().Between("Adan", "Eva").IsInTheCast("Adan").Should().BeTrue();
        Love().Between("Adan", "Eva").IsInTheCast("Eva").Should().BeTrue();
        Love().Between("Adan", "Eva").IsInTheCast("IsNot").Should().BeFalse();
    }
}