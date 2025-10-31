using UnityEngine;

public class Stats : MonoBehaviour
{

    [SerializeField] private float maxHp;
    [SerializeField] private float hp;
    [SerializeField] private float armor = 0;
    [SerializeField] private float cooldownReduction = 1;
    [SerializeField] private float attackDamage = 1;
    [SerializeField] private string visualName;
    private Animator animator;

    private void Awake()
    {
        hp = maxHp;
        animator = transform.Find(visualName).GetComponent<Animator>();
    }
    
    
    public void TakeDamage(float amount)
    {
        float damage = amount - armor;
        if(damage < 0) {damage = 0;}
        hp -= damage;
        if (hp <= 0) {Die();}
    }

    public void Die()
    {
        animator.SetBool("die", true);
    }

    public float getAttackDamage()
    {
        return attackDamage;
    }

    public float getMaxHp()
    {
        return maxHp;
    }

    public float getArmor()
    {
        return armor;
    }

    public float getCooldownReduction()
    {
        return cooldownReduction;
    }

    public float getHp()
    {
        return hp;
    }

}
