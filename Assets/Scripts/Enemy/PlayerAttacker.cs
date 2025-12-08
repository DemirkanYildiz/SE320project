using System;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    
    [SerializeField] private Animator animator;
    
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("attack");
        }
    }
    
}
