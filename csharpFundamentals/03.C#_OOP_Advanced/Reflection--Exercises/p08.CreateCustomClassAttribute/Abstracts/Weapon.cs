using System.Linq;
using System.Text;

[SoftUni("Pesho", "Used for C# OOP Advanced Course - Enumerations and Attributes.", 3, "Pesho", "Svetlio")]
public abstract class Weapon : IWeapon
{
    private string name;
    private int minDamage;
    private int maxDamage;
    private IGem[] gems;
    private WeaponRarityType rarityType;
    
    protected Weapon(string name, int minDamage, int maxDamage, IGem[] gems, WeaponRarityType rarityType)
    {
       this.Name = name;
       this.MinDamage = minDamage;
       this.MaxDamage = maxDamage;
       this.Gems = gems;
       this.RarityType = rarityType;
    }

    public WeaponRarityType RarityType
    {
        get
        {
            return this.rarityType;
        }
        private set
        {
            this.rarityType = value;
        }
    }

    public IGem[] Gems
    {
        get
        {
            return this.gems;
        }
        private set
        {
            this.gems = value;
        }
    }

    public int MaxDamage
    {
        get
        {
            return this.maxDamage;
        }
        private set
        {
            this.maxDamage = value;
        }
    }

    public int MinDamage
    {
        get
        {
            return this.minDamage;
        }
        private set
        {
            this.minDamage = value;
        }
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            this.name = value;
        }
    }

    public void AddGem(int socketIndex, IGem gem)
    {
        if (0 <= socketIndex && socketIndex < this.Gems.Length)
        {
            var lastGem = this.Gems.ElementAtOrDefault(socketIndex);
            if (lastGem != null)
            {
                this.MinDamage -= lastGem.AdditiveMinDamage;
                this.MaxDamage -= lastGem.AdditiveMaxDamage;
            }
            this.Gems[socketIndex] = gem;
        }
        else return;

        this.MinDamage += gem.AdditiveMinDamage;
        this.MaxDamage += gem.AdditiveMaxDamage;
    }

    public void RemoveGem(int socketIndex)
    {
        var gem = this.Gems.ElementAtOrDefault(socketIndex);
        if (gem == null) return;

        this.MinDamage -= gem.AdditiveMinDamage;
        this.maxDamage -= gem.AdditiveMaxDamage;

        this.Gems[socketIndex] = null;
    }

    public override string ToString()
    {
        var totalStrength = this.Gems.Where(g => g != null).Sum(g => g.Strength);
        var totalAgi = this.Gems.Where(g => g != null).Sum(g => g.Agility);
        var totalVit = this.Gems.Where(g => g != null).Sum(g => g.Vitality);

        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{totalStrength} Strength, +{totalAgi} Agility, +{totalVit} Vitality");
        var result = sb.ToString().TrimEnd();

        return result;
    }
}