using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    private float maxHp;
    private float hp;
    private float armor;
    private float attackSpeed;


    void Start()
    {
        
    }
    
    public void TakeDamage(float amount)
    {
        hp -= amount;
        if (hp <= 0)
        {

        }
    }

    public void Die()
    {

    }

}
