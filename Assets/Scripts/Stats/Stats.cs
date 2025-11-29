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
    [SerializeField] private string visualName;
    private Animator animator;

    
    public event Action<float, float> OnHealthChanged;

    private void Awake()
    {
        hp = maxHp;
        
        if (!string.IsNullOrEmpty(visualName))
        {
            Transform visualTransform = transform.Find(visualName);
            if (visualTransform != null)
                animator = visualTransform.GetComponent<Animator>();
        }
    }

    
    private void Start()
    {
        OnHealthChanged?.Invoke(hp, maxHp);
    }

    public void TakeDamage(float amount)
    {
        float damage = amount - armor;
        if (damage < 0) { damage = 0; }

        hp -= damage;

        
        OnHealthChanged?.Invoke(hp, maxHp);

        if (hp <= 0) { Die(); }
    }

    public void Die()
    {
        if (animator != null) animator.SetBool("die", true);
    }

    public void OnDestroy()
    {
        if (gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(0);
        }
    }

    
    public float getAttackDamage() { return attackDamage; }
    public float getMaxHp() { return maxHp; }
    public float getArmor() { return armor; }
    public float getCooldownReduction() { return cooldownReduction; }
    public float getHp() { return hp; }
}