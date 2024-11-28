using UnityEngine;
using UnityEngine.UI;  // Import UI namespace to work with UI elements

public class PictureChanger : MonoBehaviour
{
    public Image original;
    public Sprite newSprite;

    public void NewImage()
    {
        original.sprite = newSprite;
    }
}

