using System.Runtime.CompilerServices;
using classes01.Model.Entities;

namespace classes01.Model;

public abstract class Entity
{
    private const int BaseHp = 100;
    private const int DeadHp = 0;
    
    private static Random Random = null!;
    public Guid Id { get; }
    public string Name { get; }
    public float Hp { get; set; }

    public Entity(string name, int hp = BaseHp)
    {
        Name = name;
        Hp = hp;
        Id = Guid.NewGuid();
    }

    public abstract void TakeDamage(float dmg, Entity attacker);

    public bool IsDefeated() => Hp <= DeadHp;
}