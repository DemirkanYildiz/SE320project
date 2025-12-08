using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    private Transform playerCamTransform;
    [SerializeField] private Stats enemyStats;
    [SerializeField] private Transform hpTransform;

    public void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerCamTransform = player.transform.Find("PlayerCameraRoot").GetComponent<Transform>();
    }

    public void OnEnable()
    {
        enemyStats.OnHealthChanged += setHp;
    }
    
    public void OnDisable()
    {
        enemyStats.OnHealthChanged -= setHp;
    }

    public void LateUpdate()
    {
        transform.LookAt(transform.position + playerCamTransform.forward, playerCamTransform.up);
    }   

    public void setHp(float hp, float maxHp)
    {
        float ratio = hp / maxHp;
        hpTransform.localScale = new Vector3(ratio, 1, 1);
        hpTransform.localPosition = new Vector3(0.5f * ratio - 0.5f, 0, 0);
    }
    
}
