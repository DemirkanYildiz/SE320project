using UnityEngine;

public class KnifeController : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 3f;
    public float damage = 20f;

    [Header("Ayarlar")]
    public string targetTag; 
    public string ownerTag;  

    void Start()
    {
        
        GetComponent<Rigidbody>().linearVelocity = transform.forward * speed;
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag(ownerTag)) return;

        
        if (other.CompareTag(targetTag))
        {
            Stats targetStats = other.GetComponent<Stats>();
            if (targetStats != null)
            {
                targetStats.TakeDamage(damage);
                Destroy(gameObject); 
            }
        }
        
        else if (!other.isTrigger)
        {
            Destroy(gameObject);
        }
    }
}