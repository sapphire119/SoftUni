public class Amethyst : Gem
{
    private const int DefaultStrength = 2;
    private const int DefaultAgility = 8;
    private const int DefaultVitality = 4;

    public Amethyst(GemType gemType)
        : base(DefaultStrength + (int)gemType, DefaultAgility + (int)gemType, DefaultVitality + (int)gemType, gemType)
    {
    }
}