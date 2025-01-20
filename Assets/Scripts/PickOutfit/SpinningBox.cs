using UnityEngine; // Importing the Unity engine namespace.
using UnityEngine.UI; // Importing the Unity UI namespace for working with UI components.

public class SpinningBox : MonoBehaviour // Declaring a MonoBehaviour-derived class called SpinningBox.
{
    public Sprite[] items; // Array to hold the sprites that the box will spin through.
    private float spinSpeed = 0.6f; // Time interval (in seconds) for how quickly the box spins to the next sprite.
    private Image boxImage; // Reference to the Image component from Unity used to display the sprite.
    private bool isSpinning = true; // Boolean to track whether the box is currently spinning.
    private int currentIndex = 0; // Index to track the current sprite being displayed.

    void Start()
    {
        // Get the Image component attached to this GameObject.
        boxImage = GetComponent<Image>();
        // Repeatedly call the Spin method at intervals defined by spinSpeed.
        InvokeRepeating("Spin", spinSpeed, spinSpeed);
    }

    void Spin()
    {
        // Check if the box is currently spinning.
        if (isSpinning)
        {
            // Increment the current index and wrap around if it exceeds the array length.
            currentIndex = (currentIndex + 1) % items.Length;
            // Update the displayed sprite to the one at the current index.
            boxImage.sprite = items[currentIndex];
        }
    }

    public void StopSpinning()
    {
        // Stop the spinning by setting isSpinning to false.
        isSpinning = false;
    }

    public Sprite GetSelectedSprite()
    {
        // Return the currently displayed sprite.
        return boxImage.sprite;
    }

    public int GetSelectedIndex()
    {
        // Return the index of the currently displayed sprite.
        return currentIndex;
    }
}
