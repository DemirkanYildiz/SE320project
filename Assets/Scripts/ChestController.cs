using UnityEngine;

public class ChestController : MonoBehaviour
{
   
    [SerializeField] private Animation chestAnimation;

    private bool isOpened = false;

    void OnTriggerEnter(Collider other)
    {
        if (isOpened) return;

        if (other.CompareTag("Player"))
        {
            Score playerScore = other.GetComponent<Score>();

            if (playerScore != null)
            {
                playerScore.incrementScore(3);
                OpenChest();
            }
        }
    }

    void OpenChest()
    {
        isOpened = true;

        if (chestAnimation != null)
        {
           
            chestAnimation.Play("ChestAnim");
        }
    }
}