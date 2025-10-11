using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimationHandler : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private InputActionReference attack;
    [SerializeField] private InputActionReference movement;
    private StarterAssetsInputs inputs;

    private void Awake()
    {
        inputs = transform.parent.GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
        
    }

    private void OnEnable()
    {
        
        attack.action.performed += AttackAnimation;
        attack.action.Enable();
        movement.action.performed += MovementAnimationPerform;
        movement.action.canceled += MovementAnimationCancel;
        movement.action.Enable();


    }

    private void OnDisable()
    {
        attack.action.performed -= AttackAnimation;
        attack.action.Disable();
        movement.action.performed -= MovementAnimationPerform;
        movement.action.canceled -= MovementAnimationCancel;
        movement.action.Disable();
    }

    void AttackAnimation(InputAction.CallbackContext obj)
    {
        animator.SetTrigger("attack");
    }

    void MovementAnimationPerform(InputAction.CallbackContext obj)
    {
        float v = inputs.move.y;
        float h = inputs.move.x;
        Debug.Log(v);
        Debug.Log(h);
        Debug.Log("-----");
        animator.SetBool("runForward", v > 0 && h == 0);
        animator.SetBool("runBackward", v < 0 && h == 0);
        animator.SetBool("runRight", h > 0 && v >= 0);
        animator.SetBool("runLeft", h < 0 && v >= 0);
        animator.SetBool("runBackwardRight", v < 0 && h > 0);
        animator.SetBool("runBackwardLeft", v < 0 && h < 0);
    }

    void MovementAnimationCancel(InputAction.CallbackContext obj)
    {
        Debug.Log("animations canceled");
        animator.SetBool("runForward", false);
        animator.SetBool("runBackward", false);
        animator.SetBool("runRight", false);
        animator.SetBool("runLeft", false);
        animator.SetBool("runBackwardRight", false);
        animator.SetBool("runBackwardLeft", false);
    }

}
