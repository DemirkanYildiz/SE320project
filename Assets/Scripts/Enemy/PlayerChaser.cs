using System;
using UnityEngine;

public class PlayerChaser : MonoBehaviour
{

    [SerializeField] private float speed = 1;
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform enemyVisualTransform;
    [SerializeField] private float rotationSpeed = 1;

    public void OnTriggerStay(Collider other)
    {
        if (animator.GetBool("die")) {return;}

        if (!other.CompareTag("Player")) {return;}
        
        Vector3 toPlayer = other.transform.position - transform.position;
        float distance = toPlayer.magnitude;

        bool shouldRun = distance >= 2f;
        animator.SetBool("running", shouldRun);
        
        if (shouldRun)
        {
            Vector3 direction = toPlayer.normalized;
            controller.SimpleMove(direction * speed);
        }
        
        toPlayer.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(toPlayer);
        enemyVisualTransform.rotation = Quaternion.Slerp(enemyVisualTransform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    public void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        animator.SetBool("running", false);
    }

    
    
}
