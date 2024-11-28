using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Speed of movement

    void Update()
    {
        // Get horizontal input (left/right arrows or A/D keys)
        float move = Input.GetAxis("Horizontal");

        // Move the player left and right
        transform.Translate(Vector2.right * move * moveSpeed * Time.deltaTime);
    }
}
