using FluentAssertions;
using LanguageExt;
using static LanguageExt.Option<CubeConundrumAgain.Scene>;

namespace CubeConundrumAgain;

public class Tests
{
    [Test]
    public void OnceUponATime()
    {
        Story.OnceUponATime().IsAlive("Adan").Should().BeTrue();
        Story.OnceUponATime().IsAlive("Eva").Should().BeTrue();
    }

    [Test]
    public void BuryAdan()
    {
        Scene.Death().Buried("Adan").IsInTheTomb("Adan").Should().BeTrue();

        Story.OnceUponATime()
            .Happened(Scene.Death().Buried("Adan"))
            .IsAlive("Adan").Should().BeFalse();
    }
}

public class Scene
{
    readonly string buriedOne;

    public Scene(string buriedOne) => this.buriedOne = buriedOne;

    public static Scene Death()
    {
        return new("");
    }

    public Scene Buried(string who)
    {
        return new(who);
    }

    public bool IsInTheTomb(string who)
    {
        return buriedOne == who;
    }
}

public class Story
{
    Option<Scene> scene;
    Story(Option<Scene> scene) => this.scene = scene;
    public static Story OnceUponATime() => new(None);
    public bool IsAlive(string who) => scene.Match(where => !where.IsInTheTomb(who), () => true);
    public Story Happened(Option<Scene> what) => new(what);
}