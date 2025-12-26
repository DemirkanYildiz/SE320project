using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHealInput : MonoBehaviour
{
    [SerializeField] private Stats playerStats;
    [SerializeField] private InputActionReference playerHeal;
    [SerializeField] private float cooldown = 20;
    [SerializeField] private SkillsUI skillsUI;
    private int prevFloatingDigit = -1;
    
    public void Update()
    {
        if (cooldown > 0)
        {
            int currentDigit = Mathf.FloorToInt(cooldown * 10) % 10;

            if (prevFloatingDigit == -1)
            {
                prevFloatingDigit = currentDigit;
                return;
            }

            if (currentDigit != prevFloatingDigit)
            {
                skillsUI.updateCooldownE(cooldown.ToString("#.0"));
                prevFloatingDigit = currentDigit;
            }
            
            cooldown -= Time.deltaTime * playerStats.getCooldownReduction();
            if (cooldown <= 0)
            {
                skillsUI.updateCooldownE("");
            }
        }
    }

    public void OnEnable()
    {
        playerHeal.action.performed += healPlayer;
        playerHeal.action.Enable();
    }

    public void OnDisable()
    {
        playerHeal.action.performed -= healPlayer;
        playerHeal.action.Disable();
    }

    private void healPlayer(InputAction.CallbackContext obj)
    {
        if (cooldown <= 0)
        {
            float healthGap = playerStats.getMaxHp() - playerStats.getHp();
            if (healthGap <= 0) return;
            if (healthGap <= 10) playerStats.setHp(playerStats.getHp() + healthGap);
            else playerStats.setHp(playerStats.getHp() + 10);
            cooldown = 20;
        }
    }
    
}
