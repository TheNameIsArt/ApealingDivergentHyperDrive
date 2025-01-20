using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class playerMovement : MonoBehaviour
{
    public Animator animator; // Reference to Animator
    public SceneRandomizer SceneRandomizer; // Script with the scene randomizer when winning

    private float speed = 2f;  // Forward movement speed
    public float turnSpeed = 100f; // Turning speed
    public float gameEndPositionY = -5f; // Y position to trigger game end (game ends when Y reaches -5)
    private float moveDirection;
    private float currentSpeed; // Current speed
    private bool isGameEnded = false;
    AudioSource AudioSource;

    private void Start()
    {
        SceneRandomizer = GameObject.Find("DontDestroyOnLoad").GetComponent<SceneRandomizer>();
        AudioSource = GetComponent<AudioSource>();
    }
    void Update()
    {


        // Check for input
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection = -1; // Left turn
            animator.Play("left", 0); // Force play LeftTurn animation
            currentSpeed = speed; // Assign forward speed
            transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime); // Rotates the object around the forward axis.
            transform.Translate(Vector3.down * currentSpeed * Time.deltaTime); // Moves the object downward based on its speed.
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDirection = 1; // Right turn
            animator.Play("right", 0); // Force play RightTurn animation
            currentSpeed = speed; // Assign forward speed
            transform.Rotate(Vector3.forward, -turnSpeed * Time.deltaTime);
            transform.Translate(Vector3.down * currentSpeed * Time.deltaTime);
        }
        else
        {
            // Stop forward movement when no key is pressed
            currentSpeed = 0;
        }


        CheckGameEndCondition();
    }

    private void CheckGameEndCondition()
    {
        if (transform.position.y <= gameEndPositionY && !isGameEnded)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        // Pause the game by setting time scale to 0
        Debug.Log("You Win!");
        isGameEnded = true; // Prevent further execution of EndGame
        if (SceneRandomizer.Win == false)
        {
            SceneRandomizer.Win = true;
        }
    }
}
