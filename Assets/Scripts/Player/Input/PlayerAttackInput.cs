using UnityEngine;
using UnityEngine.InputSystem;

// Apply to player root.
public class PlayerAttackInput : MonoBehaviour
{

    private Animator animator;
    [SerializeField] private InputActionReference basicAttackInput;
    [SerializeField] private InputActionReference heavyAttackInput;
    private HeavyAttack heavyAttack;
    private BasicAttack basicAttack;

    private void Awake()
    {
        heavyAttack = transform.Find("HeavyAttackField").GetComponent<HeavyAttack>();
        basicAttack = transform.Find("BasicAttackField").GetComponent<BasicAttack>();
        animator = transform.Find("PlayerVisuals").GetComponent<Animator>();
    }

    private void OnEnable()
    {
        basicAttackInput.action.performed += BasicAttackPerform;
        heavyAttackInput.action.performed += HeavyAttackPerform;
        basicAttackInput.action.Enable();
        heavyAttackInput.action.Enable();
    }

    private void OnDisable()
    {
        basicAttackInput.action.performed -= BasicAttackPerform;
        heavyAttackInput.action.canceled -= HeavyAttackPerform;
        basicAttackInput.action.Disable();
        heavyAttackInput.action.Disable();
    }

    void BasicAttackPerform(InputAction.CallbackContext obj)
    {
        if(basicAttack.isReady())
        {
            animator.SetTrigger("basicAttack");
        }
    }

    void HeavyAttackPerform(InputAction.CallbackContext obj)
    {
        if (heavyAttack.isReady())
        {
            animator.SetTrigger("heavyAttack");
        }
    }



}
