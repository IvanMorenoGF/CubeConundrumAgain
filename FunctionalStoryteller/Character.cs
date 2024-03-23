namespace FunctionalStoryteller;

public sealed class Character
{
    readonly string name;

    Character(string name) => this.name = name;
    
    public static bool operator !=(Character left, Character right) => !(left == right);
    public static bool operator ==(Character left, Character right) => left?.Equals(right) ?? false;

    public override bool Equals(object other)
    {
        if (other == null) return false;

        return other is Character otherCharacter
            ? name == otherCharacter.name
            : other is string otherName && name == otherName;
    }

    public static implicit operator string(Character character) => character.name;
    public static implicit operator Character(string name) => new(name);

    public override string ToString() => name;
}