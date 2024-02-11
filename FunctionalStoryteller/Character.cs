namespace FunctionalStoryteller;

public class Character
{
    private readonly string name;

    Character(string name) => this.name = name;
    public static Character None => new("");

    public static bool operator !=(Character left, Character right) => !(left == right);
    public static bool operator ==(Character left, Character right) => left.Equals(right);

    public override bool Equals(object other)
    {
        return other is Character otherCharacter
            ? name == otherCharacter.name
            : other is string otherName && name == otherName;
    }

    public static implicit operator string(Character character) => character.name;
    public static implicit operator Character(string name) => new(name);
}