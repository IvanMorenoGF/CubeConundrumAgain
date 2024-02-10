namespace CubeConundrumAgain;

public class Character
{
    private readonly string name;

    public Character(string name) => this.name = name;
    
    public static bool operator ==(Character left, Character right) => left.name == right.name;
    public static bool operator !=(Character left, Character right) => !(left == right);
    
    public override bool Equals(object other) => other is string otherName && name == otherName;

    public static implicit operator string(Character character) => character.name;
    public static implicit operator Character(string name) => new(name);
}