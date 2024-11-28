using UnityEngine;
using UnityEngine.UI;

public class SpinningBox : MonoBehaviour
{
    public Sprite[] items; // Array of images to spin through
    private float spinSpeed = 0.2f; // Speed of spinning
    private Image boxImage; // The UI Image component
    private bool isSpinning = true; // Whether the box is spinning
    private int currentIndex = 0; // Current image index

    void Start()
    {
        boxImage = GetComponent<Image>();
        InvokeRepeating("Spin", spinSpeed, spinSpeed);
    }

    void Spin()
    {
        if (isSpinning)
        {
            currentIndex = (currentIndex + 1) % items.Length;
            boxImage.sprite = items[currentIndex];
        }
    }

    public void StopSpinning()
    {
        isSpinning = false;
    }

    public Sprite GetSelectedSprite()
    {
        return boxImage.sprite; // Returns the currently displayed sprite
    }

    public int GetSelectedIndex()
    {
        return currentIndex; // Return the index of the selected sprite
    }

}
