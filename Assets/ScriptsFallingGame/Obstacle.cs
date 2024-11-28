using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float speed;

    // Method to start moving the obstacle upward
    public void StartMoving(float obstacleSpeed)
    {
        speed = obstacleSpeed;
    }

    void Update()
    {
        // Move the obstacle upwards
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    // Optionally: Destroy the obstacle once it moves off the top of the screen
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

