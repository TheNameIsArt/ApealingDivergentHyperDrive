using UnityEngine; // Importing the Unity engine namespace.
using TMPro; // Importing the TextMeshPro namespace for working with text elements.

public class PickManager : MonoBehaviour // Declaring a new MonoBehaviour-derived class called PickManager.
{
    public SpinningBox[] spinningBoxes; // Array to hold references to spinning boxes.
    public SpriteRenderer shirtSlot; // Reference to the sprite renderer for the shirt slot.
    public SpriteRenderer skirtSlot; // Reference to the sprite renderer for the skirt slot.
    public SpriteRenderer shoesSlot; // Reference to the sprite renderer for the shoes slot.
    private SceneRandomizer SceneRandomizer; // Private reference to a SceneRandomizer object.
    private int currentBox = 0; // Index of the currently spinning box, initialized to 0. So it start from the first spinning box 
    private bool gameEnded = false; // Flag to indicate whether the game has ended.
    public TMP_Text text; // Reference to a TextMeshPro text element.

    private void Start() //method
    {
        // Initialize the SceneRandomizer by finding the "DontDestroyOnLoad" object and getting its SceneRandomizer component.
        SceneRandomizer = GameObject.Find("DontDestroyOnLoad").GetComponent<SceneRandomizer>();
    }

    void Update() //method
    {
        // Check if the game is still running and the spacebar is pressed.
        if (!gameEnded && Input.GetKeyDown(KeyCode.Space))
        {
            // Check if there are still boxes left to spin.
            if (currentBox < spinningBoxes.Length)
            {
                // Stop the current spinning box.
                spinningBoxes[currentBox].StopSpinning();
                
                // Assign the selected sprite to the corresponding slot based on the current box index.
                if (currentBox == 0) shirtSlot.sprite = spinningBoxes[currentBox].GetSelectedSprite();
                if (currentBox == 1) skirtSlot.sprite = spinningBoxes[currentBox].GetSelectedSprite();
                if (currentBox == 2) shoesSlot.sprite = spinningBoxes[currentBox].GetSelectedSprite();
                
                // Move to the next box.
                currentBox++;
            }

            // If all boxes have been spun, check if the selections match.
            if (currentBox == spinningBoxes.Length)
            {
                CheckMatch();
            }
        }
    }

    void CheckMatch() //method
    {
        // Retrieve the selected index of each spinning box.
        int index1 = spinningBoxes[0].GetSelectedIndex();
        int index2 = spinningBoxes[1].GetSelectedIndex();
        int index3 = spinningBoxes[2].GetSelectedIndex();

        // Check if all indices are equal (a match).
        if (index1 == index2 && index2 == index3)
        {
            // Log a win message and update the text element.
            Debug.Log("You win!");
            text.text = "Wow! Great fit!";
            // Call the Win method after a 2-second delay.
            Invoke("Win", 2f);
        }
        else
        {
            // Log a no-match message and update the text element.
            Debug.Log("No match!");
            text.text = "Absolutely NOT!";
            // Call the Lose method after a 1-second delay.
            Invoke("Lose", 1f);
        }

        // Mark the game as ended.
        gameEnded = true;
    }

    void Win() //method
    {
        // Set the win flag in the SceneRandomizer to true.
        SceneRandomizer.Win = true;
    }

    void Lose() //method
    {
        // Trigger the gameOver method in the SceneRandomizer.
        SceneRandomizer.gameOver();
    }
}
