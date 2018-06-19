public class Hero : IHero
{
    private string name;
    private int experience;
    private IAxe weapon;

    public Hero(string name, IAxe weapon)
    {
        this.name = name;
        this.experience = 0;
        this.weapon = weapon;
    }

    public string Name
    {
        get { return this.name; }
    }

    public int Experience
    {
        get { return this.experience; }
    }

    public IAxe Weapon
    {
        get { return this.weapon; }
    }

    public void Attack(IDummy target)
    {
        this.weapon.Attack(target);

        if (target.IsDead())
        {
            this.experience += target.GiveExperience();
        }
    }
}
