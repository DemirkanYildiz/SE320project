using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    [SerializeField] protected Stats stats;
    [SerializeField] protected float cooldown;
    [SerializeField] protected GameObject attackField;
    private bool ready;
    private float currentCooldown;

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
    }

    public void AttackEnable()
    {
        currentCooldown = cooldown;
        ready = false;
        attackField.SetActive(true);
    }

    public void AttackDisable()
    {
        attackField.SetActive(false);
    }

    public abstract void Apply(Stats target);

}
