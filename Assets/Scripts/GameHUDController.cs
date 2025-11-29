using UnityEngine;
using UnityEngine.UIElements; 

public class GameHUDController : MonoBehaviour
{
    private ProgressBar healthBar; 
    private Stats playerStats;     

    void OnEnable()
    {
        
        var uiDocument = GetComponent<UIDocument>();
        if (uiDocument == null) return;

        var root = uiDocument.rootVisualElement;
        healthBar = root.Q<ProgressBar>("health-bar");

        
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            playerStats = player.GetComponent<Stats>();

            if (playerStats != null)
            {
                
                playerStats.OnHealthChanged += UpdateHealthUI;

               
                UpdateHealthUI(playerStats.getHp(), playerStats.getMaxHp());
            }
        }
        else
        {
            Debug.LogWarning("GameHUDController: 'Player' tag'ine sahip nesne bulunamad�!");
        }
    }

    void OnDisable()
    {
        
        if (playerStats != null)
        {
            playerStats.OnHealthChanged -= UpdateHealthUI;
        }
    }

    
    void UpdateHealthUI(float currentHp, float maxHp)
    {
        if (healthBar != null)
        {
            
            healthBar.highValue = maxHp;
            
            healthBar.value = currentHp;
        }
    }
}