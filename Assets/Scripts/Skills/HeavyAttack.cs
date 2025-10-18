using UnityEngine;

//attack that scales with both armor and attackdamage
public class HeavyAttack : Attack
{

    public override void Apply(GameObject enemy)
    {
        Stats enemyStats = enemy.GetComponent<Stats>();
        enemyStats.TakeDamage(this.stats.getAttackDamage() * 1.25f + this.stats.getArmor() * 0.25f);
    }

}
