using FluentAssertions;
using static FunctionalStoryteller.Scenes;
using static FunctionalStoryteller.Specs;
using static FunctionalStoryteller.Storyteller;
using static FunctionalStoryteller.Tests.CharactersToTestsWith;

namespace FunctionalStoryteller.Tests;

public class Chapter2Tests
{
    [Test]
    public void Level1()
    {
        // Edgar, Lenora, Isobel, Bernard
        // Se da el amor entre Adam y Eve
        // Se muere uno y el otro lo ve
        // El personaje viudo vuelve a enamorarse
        
        // Otro caso
        // Se da el amor entre Adam y Eve
        // Se da el amor entre Adam y Enriqueto
        // Se da el amor entre Enriqueto y otra persona (que no sea Adam ni Eve)
    }
}

public class Chapter1Tests
{
    [Test]
    public void Level1()
    {
        OnceUponATime()
            .Happened(Solitude().Of(Adam))
            .Happened(Love().Between(Adam, Eve))
            .Happened(Death().Of(Adam))
            .Then(InLoveWith(Adam, Eve), Not(Alive(Adam)))
            .Should().BeTrue("se entiende que Adán muere feliz si Eva lo ama");
    }

    [Test]
    public void Level2()
    {
        OnceUponATime()
            .Happened(Love().Between(Adam, Eve))
            .Happened(Death().Of(Adam).WatchedBy(Eve))
            .Happened(Death().Of(Eve))
            .Then(Heartbroken(Eve), Not(Alive(Eve)))
            .Should().BeTrue("muere desconsolada por saber la muerte de Adán");
    }

    [Test]
    public void Level3()
    {
        OnceUponATime()
            .Happened(Love().Between(Adam, Eve))
            .Happened(Death().Of(Adam).WatchedBy(Eve))
            .Happened(Love().Between(Adam, Eve))
            .Then(InLoveWith(Eve, Adam), Scared(Eve))
            .Should().BeTrue("Eva está asustada por ver el fantasma de un amante");
    }

    [Test]
    public void Level4()
    {
        OnceUponATime()
            .Happened(Love().Between(Adam, Eve))
            .Happened(Death().Of(Adam).WatchedBy(Eve))
            .Happened(Revive().Of(Adam))
            .Happened(Love().Between(Adam, Eve))
            .Then(Was(Heartbroken(Eve)),Not(Heartbroken(Eve)))
            .Should().BeTrue("Eva se consuela al ver a su amante revivido");
    }
}