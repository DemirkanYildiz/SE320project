using UnityEngine;

public class AttackApplier : MonoBehaviour
{

    [SerializeField] private Attack attack;
    [SerializeField] private string enemyTag;
    
    public void OnTriggerEnter(Collider other)
    {
        
        Stats enemyStats = other.gameObject.GetComponent<Stats>();
        Debug.Log("trigger enter");
        if (other.gameObject.CompareTag(enemyTag) && enemyStats != null)
        {
            attack.Apply(enemyStats);
        }
    }
    
}
