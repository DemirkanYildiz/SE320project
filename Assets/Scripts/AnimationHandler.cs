using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class AnimationHandler : MonoBehaviour
{

    private Animator animator;
    [SerializeField] private InputActionReference attack;
    [SerializeField] private InputActionReference movement;
    private Vector2 moveVector;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        moveVector = transform.parent.GetComponent<StarterAssetsInputs>().move;
    }

    private void OnEnable()
    {
        attack.action.performed += attackAnimation;
        attack.action.Enable();
        movement.action.performed += movementAnimation;
        movement.action.Enable();
     
    }

    private void OnDisable()
    { 
        attack.action.performed -= attackAnimation;
        attack.action.Disable();
        movement.action.performed -= movementAnimation;
        movement.action.Disable();
    }

    void attackAnimation(InputAction.CallbackContext obj)
    {
        animator.SetTrigger("attack");
    }
    
    void movementAnimation(InputAction.CallbackContext obj)
    {
        float v = moveVector.x;
        float h = moveVector.y;
        animator.SetBool("runForward", v > 0 && h == 0);
        animator.SetBool("runBackward", v < 0 && h == 0);
        animator.SetBool("runRight", v == 0 && h > 0);
        animator.SetBool("runLeft", v == 0 && h < 0);
        animator.SetBool("runBackwardRight", v < 0 && h > 0);
        animator.SetBool("runBackwardLeft", v < 0 && h < 0);
    }

}
