using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class StatsVisual : MonoBehaviour
{
    
    [SerializeField] private InputActionReference switchStats;
    [SerializeField] private GameHUDController hpBarController;
    
    private Stats stats;
    private Score playerScore;
    
    private VisualElement root;
    
    private Label MaxHP;
    private Label Armor;
    private Label AD;
    private Label CDR;
    private Label points;
    
    
    private bool opened = false;

    public void Awake()
    {
        stats = transform.parent.GetComponent<Stats>();
        playerScore = transform.parent.GetComponent<Score>();
        root = GetComponent<UIDocument>().rootVisualElement;
        MaxHP = root.Q<Label>("MaxHP");
        Armor = root.Q<Label>("Armor");
        AD = root.Q<Label>("AttackDamage");
        CDR = root.Q<Label>("CooldownReduction");
        points = root.Q<Label>("Point");
        root.style.display = DisplayStyle.None;
    }

    private void OnEnable()
    {
        switchStats.action.performed += Switch;
        switchStats.action.Enable();
    }
    
    private void OnDisable()
    {
        switchStats.action.performed -= Switch;
        switchStats.action.Disable();
    }

    private void Switch(InputAction.CallbackContext context)
    {
        if (opened)
        {
            root.style.display = DisplayStyle.None;
            opened = false;
        }
        else
        {
            refresh();
            root.style.display = DisplayStyle.Flex;
            opened = true;
        }
    }

    public void refresh()
    {
        MaxHP.text = "HP(1, price:3):" + stats.getMaxHp();
        Armor.text = "Armor(2, price:3):" + stats.getArmor();
        AD.text = "Attack Damage(3, price:4):" + stats.getAttackDamage();
        CDR.text = "Cooldown Reduction(4, price:2):" + stats.getCooldownReduction();
        points.text = "Points:" + playerScore.getScore();
        hpBarController.UpdateHealthUI(stats.getHp(), stats.getMaxHp());
    }
    
}
