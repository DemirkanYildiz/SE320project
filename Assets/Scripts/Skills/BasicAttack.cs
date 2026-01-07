using System.Runtime.CompilerServices;
using UnityEngine;

//attack that scales with only attack damage.
public class BasicAttack : Attack
{

    [SerializeField] private PlayerBuffInput playerBuffInput; 
    
    public override void Apply(Stats enemyStats)
    {
        if (playerBuffInput != null)
        {
            enemyStats.TakeDamage(stats.getAttackDamage() * playerBuffInput.GetMultiplier());
        }
        else
        {
            enemyStats.TakeDamage(stats.getAttackDamage());
        }
    }

    protected override void UpdateUI()
    {
        if (ready)
        {
            skillsUI.updateCooldownLMB("");
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
            skillsUI.updateCooldownLMB(currentCooldown.ToString("#.0"));
            prevFloatingDigit = currentDigit;
        }
    }
    
}
