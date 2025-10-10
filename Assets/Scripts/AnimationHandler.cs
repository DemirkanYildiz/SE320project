using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationHandler : MonoBehaviour
{

    private Animator animator;
    //[SerializeField] private InputActionReference move;
    [SerializeField] private InputActionReference attack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        attack.action.performed += attackAnimation;
        attack.action.Enable();
    }

    private void OnDisable()
    { 
        attack.action.performed -= attackAnimation;
        attack.action.Disable();
    }

    void attackAnimation(InputAction.CallbackContext obj)
    {
        animator.SetTrigger("attack");
    }

}
