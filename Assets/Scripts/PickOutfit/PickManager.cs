using UnityEngine;

public class PickManager : MonoBehaviour
{
    public SpinningBox[] spinningBoxes; // Array of spinning boxes
    public SpriteRenderer shirtSlot; // SpriteRenderer for the top
    public SpriteRenderer skirtSlot; // SpriteRenderer for the bottom
    public SpriteRenderer shoesSlot; // SpriteRenderer for the shoes

    private int currentBox = 0;
    private bool gameEnded = false;

    void Update()
    {
        if (!gameEnded && Input.GetKeyDown(KeyCode.Space))
        {
            if (currentBox < spinningBoxes.Length)
            {
                spinningBoxes[currentBox].StopSpinning();
                
                if (currentBox == 0) shirtSlot.sprite = spinningBoxes[currentBox].GetSelectedSprite();
                if (currentBox == 1) skirtSlot.sprite = spinningBoxes[currentBox].GetSelectedSprite();
                if (currentBox == 2) shoesSlot.sprite = spinningBoxes[currentBox].GetSelectedSprite();
                
                currentBox++;
            }

            if (currentBox == spinningBoxes.Length)
            {
                CheckMatch();
            }
        }
    }

    void CheckMatch()
    {
        int index1 = spinningBoxes[0].GetSelectedIndex();
        int index2 = spinningBoxes[1].GetSelectedIndex();
        int index3 = spinningBoxes[2].GetSelectedIndex();

        if (index1 == index2 && index2 == index3)
        {
            Debug.Log("You win!");
        }
        else
        {
            Debug.Log("No match!");
        }

        gameEnded = true;
    }
}
