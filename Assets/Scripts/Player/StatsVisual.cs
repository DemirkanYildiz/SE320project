using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class StatsVisual : MonoBehaviour
{
    
    [SerializeField] private InputActionReference switchStats;
    
    private Stats stats;
    
    private VisualElement root;
    
    private Label MaxHP;
    private Label Armor;
    private Label AD;
    private Label CDR;
    
    
    private bool opened = false;

    public void Awake()
    {
        stats = transform.parent.GetComponent<Stats>();
        root = GetComponent<UIDocument>().rootVisualElement;
        MaxHP = root.Q<Label>("MaxHP");
        Armor = root.Q<Label>("Armor");
        AD = root.Q<Label>("AttackDamage");
        CDR = root.Q<Label>("CooldownReduction");
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
            MaxHP.text = "HP:" + stats.getMaxHp();
            Armor.text = "Armor:" + stats.getArmor();
            AD.text = "Attack Damage:" + stats.getAttackDamage();
            CDR.text = "Cooldown Reduction:" + stats.getCooldownReduction();
            root.style.display = DisplayStyle.Flex;
            opened = true;
        }
    }
    
}
