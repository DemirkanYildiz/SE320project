using System;
using UnityEngine;

public class PlayerChaser : MonoBehaviour
{

    [SerializeField] private float speed = 1;
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform enemyVisualTransform;

    public void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        Vector3 toPlayer = other.transform.position - transform.position;
        float distance = toPlayer.magnitude;

        bool shouldRun = distance >= 1f;
        animator.SetBool("running", shouldRun);

        if (shouldRun)
        {
            Vector3 dir = toPlayer.normalized;
            controller.SimpleMove(dir * speed);
        }

        enemyVisualTransform.LookAt(other.transform.position);
    }

    public void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        animator.SetBool("running", false);
    }

    
    
}
