using UnityEngine;

public abstract class Attack : MonoBehaviour
{

    protected Collider attackField;
    protected Stats stats;
    [SerializeField] protected string enemyTag;
    [SerializeField] protected float cooldown;
    private bool ready;
    private float currentCooldown;

    public bool isReady()
    {
        return ready;
    }

    public void Awake()
    {
        attackField = GetComponent<Collider>();
        stats = transform.parent.GetComponent<Stats>();
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
        attackField.enabled = true;
    }

    public void AttackDisable()
    {
        attackField.enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggered");
        if (other.gameObject.CompareTag(enemyTag))
        {
            Debug.Log("applying...");
            Apply(other.gameObject);
        }
    }

    public abstract void Apply(GameObject enemy);


}
