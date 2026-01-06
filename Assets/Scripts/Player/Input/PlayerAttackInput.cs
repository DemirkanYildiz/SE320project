using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackInput : MonoBehaviour
{
    private Animator animator;

    [Header("Existing Attacks")]
    [SerializeField] private InputActionReference basicAttackInput;
    [SerializeField] private InputActionReference heavyAttackInput;

    [Header("Ranged Attack Settings")]
    [SerializeField] private InputActionReference rangedAttackInput;
    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private Transform knifeSpawnPoint;

    
    [SerializeField] private int maxKnifeCount = 5; 
    private int currentKnifeCount; 
    

    private HeavyAttack heavyAttack;
    private BasicAttack basicAttack;

    private void Awake()
    {
        heavyAttack = transform.Find("HeavyAttack").GetComponent<HeavyAttack>();
        basicAttack = transform.Find("BasicAttack").GetComponent<BasicAttack>();
        animator = transform.Find("PlayerVisuals").GetComponent<Animator>();
    }

    private void Start()
    {
        
        currentKnifeCount = maxKnifeCount;
    }

    private void OnEnable()
    {
        basicAttackInput.action.performed += BasicAttackPerform;
        heavyAttackInput.action.performed += HeavyAttackPerform;
        rangedAttackInput.action.performed += RangedAttackPerform;

        basicAttackInput.action.Enable();
        heavyAttackInput.action.Enable();
        rangedAttackInput.action.Enable();
    }

    private void OnDisable()
    {
        basicAttackInput.action.performed -= BasicAttackPerform;
        heavyAttackInput.action.performed -= HeavyAttackPerform;
        rangedAttackInput.action.performed -= RangedAttackPerform;

        basicAttackInput.action.Disable();
        heavyAttackInput.action.Disable();
        rangedAttackInput.action.Disable();
    }

    void BasicAttackPerform(InputAction.CallbackContext obj)
    {
        if (basicAttack.isReady())
        {
            animator.SetTrigger("basicAttack");
            basicAttack.setCooldown();
        }
    }

    void HeavyAttackPerform(InputAction.CallbackContext obj)
    {
        if (heavyAttack.isReady())
        {
            animator.SetTrigger("heavyAttack");
            heavyAttack.setCooldown();
        }
    }

    void RangedAttackPerform(InputAction.CallbackContext obj)
    {
        
        if (currentKnifeCount > 0) 
        {
            if (knifePrefab != null && knifeSpawnPoint != null)
            {
                Instantiate(knifePrefab, knifeSpawnPoint.position, knifeSpawnPoint.rotation);

                currentKnifeCount--;
                Debug.Log(currentKnifeCount + "knives remained");
            }
        }
        else
        {
            Debug.Log("There is no knife");
        }
        
    }
}