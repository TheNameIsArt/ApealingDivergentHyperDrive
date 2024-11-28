using UnityEngine;

public class SpotlightTrigger : MonoBehaviour
{
    public bool isPlayerInSpotlight = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInSpotlight = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInSpotlight = false;
        }
    }
}
