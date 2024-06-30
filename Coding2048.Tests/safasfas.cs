namespace Coding2048.Tests;

public static class safasfas
{
    public static int CountsOf(this Game2048 game, int number)
    {
        return game.ToString().Count(x => x == number.ToString()[0]);
    }
}