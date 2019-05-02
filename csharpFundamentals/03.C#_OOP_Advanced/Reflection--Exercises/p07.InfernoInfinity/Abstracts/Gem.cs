using System;

public abstract class Gem : IGem
{
    private const int MinStrengthGemMultiplier = 2;
    private const int MaxStrengthGemMultiplier = 3;

    private const int MinAgilityGemMultiplier = 1;
    private const int MaxAgilityGemMultiplier = 4;

    protected Gem(int strength, int agility, int vitality, GemType gemType)
    {
       this.Strength = strength;
       this.Agility = agility;
       this.Vitality = vitality;
       this.GemType = gemType;
    }

    public int Strength { get; private set; }

    public int Agility { get; private set; }

    public int Vitality { get; private set; }

    public GemType GemType { get; private set; }

    public int AdditiveMinDamage => CalculateMinAdditiveDamage();

    public int AdditiveMaxDamage => CalculateMaxAdditiveDamage();

    private int CalculateMinAdditiveDamage()
    {
        var addMinDamageStrenth = this.Strength * MinStrengthGemMultiplier;
        var addMinDamageAgility = this.Agility * MinAgilityGemMultiplier;

        var totalMinDamageToAdd = addMinDamageStrenth + addMinDamageAgility;

        return totalMinDamageToAdd;
    }

    private int CalculateMaxAdditiveDamage()
    {
        var addMaxDamageStrength = this.Strength * MaxStrengthGemMultiplier;
        var addMaxDamageAgility = this.Agility * MaxAgilityGemMultiplier;
        
        var totalMaxDamageToAdd = addMaxDamageStrength + addMaxDamageAgility;

        return totalMaxDamageToAdd;
    }
}