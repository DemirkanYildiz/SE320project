using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

// Apply to player root.
public class PlayerMovementInput : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private InputActionReference movement;
    private StarterAssetsInputs inputs;

    private void Awake()
    {
        inputs = GetComponent<StarterAssetsInputs>();
        animator = transform.Find("PlayerVisuals").GetComponent<Animator>();
    }

    private void OnEnable()
    {  
        movement.action.performed += MovementAnimationPerform;
        movement.action.canceled += MovementAnimationCancel;
        movement.action.Enable();
    }

    private void OnDisable()
    {
        movement.action.performed -= MovementAnimationPerform;
        movement.action.canceled -= MovementAnimationCancel;
        movement.action.Disable();
    }


    void MovementAnimationPerform(InputAction.CallbackContext obj)
    {
        float v = inputs.move.y;
        float h = inputs.move.x;
        animator.SetBool("runForward", v > 0 && h == 0);
        animator.SetBool("runBackward", v < 0 && h == 0);
        animator.SetBool("runRight", h > 0 && v >= 0);
        animator.SetBool("runLeft", h < 0 && v >= 0);
        animator.SetBool("runBackwardRight", v < 0 && h > 0);
        animator.SetBool("runBackwardLeft", v < 0 && h < 0);
    }

    void MovementAnimationCancel(InputAction.CallbackContext obj)
    {
        animator.SetBool("runForward", false);
        animator.SetBool("runBackward", false);
        animator.SetBool("runRight", false);
        animator.SetBool("runLeft", false);
        animator.SetBool("runBackwardRight", false);
        animator.SetBool("runBackwardLeft", false);
    }

}
