using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Score : MonoBehaviour
{

    [SerializeField] private InputActionReference incrementMaxHpAction;
    [SerializeField] private InputActionReference incrementArmorAction;
    [SerializeField] private InputActionReference incrementAdAction;
    [SerializeField] private InputActionReference incrementCdrAction;
    [SerializeField] private Stats playerStats;
    [SerializeField] private StatsVisual statsVisual;
    [SerializeField] private int score;

    public void Start()
    {
        score = 0;
    }

    public int getScore()
    {
        return score;
    }

    public void OnEnable()
    {
        incrementMaxHpAction.action.performed += incrementMaxHp;
        incrementCdrAction.action.performed += incrementCDR;
        incrementAdAction.action.performed += incrementAd;
        incrementArmorAction.action.performed += incrementArmor;
        incrementMaxHpAction.action.Enable();
        incrementCdrAction.action.Enable();
        incrementAdAction.action.Enable();
        incrementArmorAction.action.Enable();
    }
    
    public void OnDisable()
    {
        incrementMaxHpAction.action.performed -= incrementMaxHp;
        incrementCdrAction.action.performed -= incrementCDR;
        incrementAdAction.action.performed -= incrementAd;
        incrementArmorAction.action.performed -= incrementArmor;
        incrementMaxHpAction.action.Disable();
        incrementCdrAction.action.Disable();
        incrementAdAction.action.Disable();
        incrementArmorAction.action.Disable();
    }

    public void incrementScore(int amount)
    {
        score += amount;
        statsVisual.refresh();
    }

    public void incrementMaxHp(InputAction.CallbackContext obj)
    {
        if (score >= 3)
        {
            score-=3;
            playerStats.setMaxHp(playerStats.getMaxHp()+10);
            statsVisual.refresh();
        }
    }

    public void incrementArmor(InputAction.CallbackContext obj)
    {
        if (score >= 3)
        {
            score-=3;
            playerStats.setArmor(playerStats.getArmor()+5);
            statsVisual.refresh();
        }
    }
    
    public void incrementCDR(InputAction.CallbackContext obj)
    {
        if (score >= 2)
        {
            score-=2;
            playerStats.setCooldownReduction(playerStats.getCooldownReduction()+1);
            statsVisual.refresh();
        }
    }
    
    public void incrementAd(InputAction.CallbackContext obj)
    {
        if (score >= 4)
        {
            score-=4;
            playerStats.setAttackDamage(playerStats.getAttackDamage()+10);
            statsVisual.refresh();
        }
    }

    
    
    
    
}
