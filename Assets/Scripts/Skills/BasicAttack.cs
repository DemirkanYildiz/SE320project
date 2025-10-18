using UnityEngine;

//attack that scales with only attack damage.
public class BasicAttack : Attack
{

    public override void Apply(GameObject enemy)
    {      
        Stats enemyStats = enemy.GetComponent<Stats>();
        Debug.Log(enemyStats.getHp());
        enemyStats.TakeDamage(this.stats.getAttackDamage());
    }
}
