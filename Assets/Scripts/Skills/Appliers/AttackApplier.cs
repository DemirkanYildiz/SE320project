using UnityEngine;

public class AttackApplier : MonoBehaviour
{

    [SerializeField] private Attack attack;
    [SerializeField] private string enemyTag;
    
    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.tag);
        Stats enemyStats = other.gameObject.GetComponent<Stats>();
        if (other.gameObject.CompareTag(enemyTag) && enemyStats != null)
        {
            attack.Apply(enemyStats);
        }
    }
    
}
