using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    [SerializeField] protected Stats stats;
    [SerializeField] protected float cooldown;
    [SerializeField] protected GameObject attackField;
    protected bool ready = true;
    protected float currentCooldown;
    [SerializeField] protected SkillsUI skillsUI;
    protected int prevFloatingDigit = -1;
    
    public bool isReady()
    {
        return ready;
    }

    public void Awake() {
        currentCooldown = cooldown;
    }

    public void Update()
    {
        if (ready) return;
        currentCooldown -= Time.deltaTime * stats.getCooldownReduction(); 
        if (currentCooldown < 0) ready = true;
        UpdateUI();
    }

    protected abstract void UpdateUI();

    public void AttackEnable()
    {
        attackField.SetActive(true);
    }

    public void setCooldown()
    {
        currentCooldown = cooldown;
        ready = false;
    }

    public void AttackDisable()
    {
        attackField.SetActive(false);
    }

    public abstract void Apply(Stats target);
    

}
