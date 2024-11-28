using UnityEngine;
using UnityEngine.UI;

public class RandomButtonPositions : MonoBehaviour
{
    public Button[] buttons; // Array to hold all the buttons
    public float minX = -300f; // Minimum x-coordinate for the random position
    public float maxX = 300f;  // Maximum x-coordinate for the random position
    public float minY = -200f; // Minimum y-coordinate for the random position
    public float maxY = 200f;  // Maximum y-coordinate for the random position

    void Start()
    {
        RandomizeButtonPositions();
    }

    void RandomizeButtonPositions()
    {
        // Loop through all the buttons and set their positions randomly
        foreach (Button button in buttons)
        {
            // Generate random positions within the specified range
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            // Set the button's position
            button.transform.position = new Vector3(randomX, randomY, button.transform.position.z);
        }
    }
}

