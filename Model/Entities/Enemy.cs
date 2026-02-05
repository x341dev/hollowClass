namespace classes01.Model.Entities;

public class Enemy : Entity
{
    public float Damage { get; set; }
    public int ExpReward { get; set; }
    
    public Enemy(string name, int hp, float damage, int expReward) : base(name, hp)
    {
        Damage = damage;
        ExpReward = expReward;
    }
    
    public override void TakeDamage(float dmg, Entity attacker)
    {
        Hp -= dmg;
        if (IsDefeated())
        {
            Console.WriteLine($"{Name} has been defeated by {attacker.Name}!");
            if (attacker is Player player)
            {
                RewardPlayer(player);
            }
        }
    }
    
    private void RewardPlayer(Player player)
    {
        player.Exp += ExpReward;
    }
}