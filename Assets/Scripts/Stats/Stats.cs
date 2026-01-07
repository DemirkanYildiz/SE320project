using System; 
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    [SerializeField] private float maxHp;
    [SerializeField] private float hp;
    [SerializeField] private float armor = 0;
    [SerializeField] private float cooldownReduction = 1;
    [SerializeField] private float attackDamage = 1;
    [SerializeField] private Animator animator;
    private bool isDead = false;

    
    public event Action<float, float> OnHealthChanged;

    private void Awake()
    {
        hp = maxHp;
        /*if (!string.IsNullOrEmpty(visualName))
        {
            Transform visualTransform = transform.Find(visualName);
            if (visualTransform != null)
                animator = visualTransform.GetComponent<Animator>();
        }*/
    }

    
    private void Start()
    {
        OnHealthChanged?.Invoke(hp, maxHp);
    }

    public void TakeDamage(float amount)
    {
        if (isDead) return;
        float percentageDamageReduction = armor / (armor + 50);
        float damage = amount * (1-percentageDamageReduction);
        hp -= damage;
        if (hp <= 0) {
            hp = 0;
            OnHealthChanged?.Invoke(hp, maxHp);
            Die();
        }
        else
        {
            OnHealthChanged?.Invoke(hp, maxHp);
        }
    }

    public void Die()
    {
        if (animator != null) animator.SetTrigger("die");
        isDead = true;
    }
    
    public float getAttackDamage() { return attackDamage; }
    public float getMaxHp() { return maxHp; }
    public float getArmor() { return armor; }
    public float getCooldownReduction() { return cooldownReduction; }

    public bool IsDead()
    {
        return isDead;
    }
    
    public void setAttackDamage(float ad) { this.attackDamage = ad; }
    public void setMaxHp(float maxHp) { this.maxHp = maxHp; }
    public void setArmor(float armor) { this.armor = armor; }
    public void setCooldownReduction(float cdr) { this.cooldownReduction = cdr; }

    public void setHp(float health)
    {
        this.hp = health;
        OnHealthChanged?.Invoke(this.hp, maxHp);
    }
    
    public float getHp() { return hp; }
}