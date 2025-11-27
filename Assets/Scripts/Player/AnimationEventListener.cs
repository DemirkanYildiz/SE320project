using UnityEngine;

// must attached to the same game object with the animator component.
public class AnimationEventListener : MonoBehaviour
{
    private BasicAttack basicAttack;
    private HeavyAttack heavyAttack;
    [SerializeField] private GameObject destroy;

    public void Awake()
    {
        basicAttack = transform.parent.Find("BasicAttack").GetComponent<BasicAttack>();
        heavyAttack = transform.parent.Find("HeavyAttack").GetComponent<HeavyAttack>();
    }

    public void BasicAttackEnable()
    {
        basicAttack.AttackEnable();
    }

    public void BasicAttackDisable()
    {
        basicAttack.AttackDisable();
    }

    public void HeavyAttackEnable()
    {
        heavyAttack.AttackEnable();
    }

    public void HeavyAttackDisable()
    {
        heavyAttack.AttackDisable();
    }

    public void DestroyObject()
    {
        Debug.Log("OnDestroy");
        Destroy(destroy);
    }


}
