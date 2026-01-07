using UnityEngine;
using UnityEngine.InputSystem;

//player r skill.
public class PlayerBuffInput : MonoBehaviour
{

    [SerializeField] private Stats playerStats;
    [SerializeField] private float attackDamageMultiplier = 1.1f;
    [SerializeField] private float cooldown = 60;
    [SerializeField] private float duration = 0;
    [SerializeField] private SkillsUI skillsUI;
    [SerializeField] private InputActionReference playerBuff;
    [SerializeField] private bool isActive = false;
    
    private int prevFloatingDigit = -1;
    private int prevFloatingDigitDuration = -1;
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
                skillsUI.updateCooldownR(cooldown.ToString("#.0"));
                prevFloatingDigit = currentDigit;
            }
            cooldown -= Time.deltaTime * playerStats.getCooldownReduction();
            if (cooldown <= 0)
            {
                skillsUI.updateCooldownR("");
            }
        }
        if (duration >= 0)
        { 
            int currentDigit = Mathf.FloorToInt(duration * 10) % 10;
            
            if (prevFloatingDigitDuration == -1)
            {
                prevFloatingDigitDuration = currentDigit;
                return;
            }

            if (currentDigit != prevFloatingDigitDuration)
            {
                skillsUI.updateDurationR(duration.ToString("#.0"));
                prevFloatingDigitDuration = currentDigit;
            }

            duration -= Time.deltaTime;
            if (duration <= 0)
            {
                isActive = false;
                skillsUI.updateDurationR("");
            }
        }
    }
    
    public void OnEnable()
    {
        playerBuff.action.performed += setBuffActive;
        playerBuff.action.Enable();
    }

    public void OnDisable()
    {
        playerBuff.action.performed -= setBuffActive;
        playerBuff.action.Disable();
    }

    private void setBuffActive(InputAction.CallbackContext obj)
    {
        if (cooldown <= 0)
        {
            isActive = true;
            cooldown = 60;
            duration = 10;
        }
    }

    public float GetMultiplier()
    {
        if (isActive) { return attackDamageMultiplier; }
        return 1;
    }
    


}
