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

        OnceUponATime()
            .Happened(Love().Between(Adam, Eve))
            .Happened(Death().Of(Adam).WatchedBy(Eve))
            .Happened(Love().Between(Eve, AnybodyElse))
            .Then(InLoveWith(Eve, AnybodyElse)).Should().BeTrue();
    }
}