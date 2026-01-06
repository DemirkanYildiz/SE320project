using UnityEngine;

public class RangedEnemyAI : MonoBehaviour
{
    public Transform player;
    public GameObject knifePrefab;
    public Transform firePoint;
    public float attackRange = 15f;
    public float attackCooldown = 3f;

    private float lastAttackTime;

    void Update()
    {
        
        if (player == null)
        {
            GameObject p = GameObject.FindWithTag("Player");
            if (p != null)
            {
                player = p.transform;
            }
            return; 
        }

        
        float distance = Vector3.Distance(transform.position, player.position);

        
        if (distance <= attackRange)
        {
            
            Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.LookAt(targetPosition);

            
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                Attack();
                lastAttackTime = Time.time;
            }
        }
    }

    void Attack()
    {
        if (knifePrefab != null && firePoint != null)
        {
            Instantiate(knifePrefab, firePoint.position, firePoint.rotation);
        }
    }
}