using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Reference to the player's Transform
    public Vector3 offset;    // The offset position of the camera

    void Update()
    {
        // Update the camera's position to follow the player
        transform.position = player.position + offset;
    }
}


