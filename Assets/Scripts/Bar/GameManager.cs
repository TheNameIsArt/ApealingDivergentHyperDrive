using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image speechBubble; // The speech bubble UI element
    public Button[] buttons; // The 6 buttons
    public Sprite[] sprites; // The 6 sprites (game sprites)
    public Sprite successSprite; // Sprite to show on correct answer
    public Sprite failureSprite; // Sprite to show on wrong answer

    private Sprite targetSprite; // The currently displayed target sprite
    private bool gameEnded = false; // To prevent further clicks after game ends

    void Start()
    {
        AssignSpritesToButtons();
        PickRandomSprite();
    }

    void AssignSpritesToButtons()
    {
        // Assign each sprite to a button
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Local copy for the lambda closure
            buttons[i].GetComponent<Image>().sprite = sprites[i];
            buttons[i].onClick.AddListener(() => OnButtonClicked(index));
        }
    }

    void PickRandomSprite()
    {
        // Randomly pick one of the sprites to display in the speech bubble
        int randomIndex = Random.Range(0, sprites.Length);
        targetSprite = sprites[randomIndex];
        speechBubble.sprite = targetSprite;
    }

    void OnButtonClicked(int buttonIndex)
    {
        if (gameEnded) return; // Ignore clicks after the game has ended

        gameEnded = true; // End the game after the first click

        if (buttons[buttonIndex].GetComponent<Image>().sprite == targetSprite)
        {
            Debug.Log("Correct!");
            speechBubble.sprite = successSprite; // Show success sprite
        }
        else
        {
            Debug.Log("Wrong!");
            speechBubble.sprite = failureSprite; // Show failure sprite
        }

        DisableAllButtons(); // Prevent further clicks
    }

    void DisableAllButtons()
    {
        foreach (var button in buttons)
        {
            button.interactable = false;
        }
    }
}
