using UnityEngine;

//attack that scales with only attack damage.
public class BasicAttack : Attack
{

    public override void Apply(Stats enemyStats)
    {      
        enemyStats.TakeDamage(this.stats.getAttackDamage());
    }
}
