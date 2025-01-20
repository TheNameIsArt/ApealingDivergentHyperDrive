using UnityEngine;

public class SpotlightTrigger : MonoBehaviour
{
    public bool isPlayerInSpotlight = false; // Indicates whether the player is currently in the spotlight.

    // Called when another collider enters the trigger zone.
    // If the collider belongs to the player, sets isPlayerInSpotlight to true.
    void OnTriggerEnter2D(Collider2D other) // other = The collider that entered the trigger zone.
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInSpotlight = true;
        }
    }

     // Called when another collider exits the trigger zone.
    // If the collider belongs to the player, sets isPlayerInSpotlight to false.
    void OnTriggerExit2D(Collider2D other) // other = The collider that exited the trigger zone.
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInSpotlight = false;
        }
    }
}
