using LanguageExt.UnsafeValueAccess;

namespace FunctionalStoryteller;

public sealed record ReviveScene : SolitudeScene
{
    public override string ToString() => $"{theOneAlone.ValueUnsafe().Name()} revived";
}