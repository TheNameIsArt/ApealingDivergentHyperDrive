using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    SceneRandomizer SceneRandomizer;
    private void Start()
    {
        SceneRandomizer = GameObject.Find("DontDestroyOnLoad").GetComponent<SceneRandomizer>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collides with an obstacle
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            SceneRandomizer.gameOver();
        }
    }
}

