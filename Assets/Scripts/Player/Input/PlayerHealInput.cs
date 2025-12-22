using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHealInput : MonoBehaviour
{
    [SerializeField] private Stats playerStats;
    [SerializeField] private InputActionReference playerHeal;
    [SerializeField] private float cooldown = 20;

    public void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime * playerStats.getCooldownReduction();
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
