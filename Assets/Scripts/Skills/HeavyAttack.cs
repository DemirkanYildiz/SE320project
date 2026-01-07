using UnityEngine;

//attack that scales with both armor and attackdamage
public class HeavyAttack : Attack
{
    
    [SerializeField] private PlayerBuffInput playerBuffInput;

    public override void Apply(Stats enemyStats)
    {
        if (playerBuffInput != null)
        {
            enemyStats.TakeDamage((stats.getAttackDamage() * 1.25f + stats.getArmor() * 0.25f) * playerBuffInput.GetMultiplier());
        }
        else
        {
            enemyStats.TakeDamage(stats.getAttackDamage() * 1.25f + stats.getArmor() * 0.25f);
        }
        
    }
    
    protected override void UpdateUI()
    {
        if (ready)
        {
            skillsUI.updateCooldownRMB("");
            return;
        }
        
        int currentDigit = Mathf.FloorToInt(currentCooldown * 10) % 10;
        if (prevFloatingDigit == -1)
        {
            prevFloatingDigit = currentDigit;
            return;
        }
        
        if (currentDigit != prevFloatingDigit)
        {
            skillsUI.updateCooldownRMB(currentCooldown.ToString("#.0"));
            prevFloatingDigit = currentDigit;
        }
    }

}
