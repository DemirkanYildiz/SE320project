using UnityEngine;

// must attached to the same game object with the animator component.
public class PlayerAnimationEventListener : MonoBehaviour
{
    private BasicAttack basicAttack;
    private HeavyAttack heavyAttack;

    public void Awake()
    {
        basicAttack = transform.parent.Find("BasicAttackField").GetComponent<BasicAttack>();
        heavyAttack = transform.parent.Find("HeavyAttackField").GetComponent<HeavyAttack>();
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


}
