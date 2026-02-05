namespace classes01.Model.Entities;

public class Player : Entity
{
    private const int StartingExp = 0, StartingLevel = 0;
    private const float BaseDmgMultiplier = 1.0f;
    
    public int Exp { get; set; }
    public int Level { get; set; }
    public Weapon CurrentWeapon { get; set; }
    public float DmgMultiplier { get; set; }
    
    public Player(string name, int hp) : base(name, hp)
    {
        Exp = StartingExp;
        Level = StartingLevel;
        DmgMultiplier = BaseDmgMultiplier;
    }

    public void EquipWeapon(Weapon weapon) => CurrentWeapon = weapon;

    public void DamageEnemy(Weapon weapon, Entity victim) => victim.TakeDamage(weapon.BaseDamage * DmgMultiplier, this);

    public override void TakeDamage(float dmg, Entity attacker)
    {
        Hp -= dmg;
        if (IsDefeated())
        {
            Console.WriteLine($"{Name} has been defeated by {attacker.Name}!");
        }
    }
}