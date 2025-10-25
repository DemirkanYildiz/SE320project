using UnityEngine;

//attack that scales with both armor and attackdamage
public class HeavyAttack : Attack
{

    public override void Apply(Stats enemyStats)
    {
        enemyStats.TakeDamage(stats.getAttackDamage() * 1.25f + stats.getArmor() * 0.25f);
    }

}
