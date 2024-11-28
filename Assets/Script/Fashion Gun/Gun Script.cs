using UnityEditor;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float rotationSpeed = 90f; // Degrees per second
    public float maxAngle = 80f; // Maximum angle from the initial position (80 degrees on each side makes 160-degree cone)
    private float currentAngle = 0f; // Current angle of rotation
    private bool rotatingUp = true; // Direction of rotation
    public bool isPaused = false; // Flag to pause rotation
    public SceneRandomizer SceneRandomizer; // Script with the scene randomizer when winning
    public float waitTime;

    private Quaternion initialRotation; // The starting rotation
    private Animator animator; // Reference to the Animator component
    public GameObject laser;
    public UniversalTimerScript timer;
    void Start()
    {
        // Store the initial rotation of the GameObject
        initialRotation = transform.rotation;

        // Get the Animator component attached to the GameObject
        animator = GetComponent<Animator>();
        SceneRandomizer = GameObject.Find("DontDestroyOnLoad").GetComponent<SceneRandomizer>();
        timer = GameObject.Find("Timer").GetComponent<UniversalTimerScript>();
        
    }

    void Update()
    {
        // Check for space key press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isPaused = true;
            
            // Trigger the animation if an Animator is available
            if (animator != null)
            {
                animator.SetTrigger("PlayAnimation");
                laser.SetActive(true);
                
            }

            return; // Stop further updates for this frame
        }

        // Skip rotation logic if paused
        if (isPaused) return;

        // Calculate the amount of rotation for this frame, considering Time.timeScale
        float deltaAngle = rotationSpeed * Time.deltaTime;

        if (rotatingUp)
        {
            // Rotate up
            currentAngle += deltaAngle;
            if (currentAngle >= maxAngle)
            {
                currentAngle = maxAngle; // Clamp to the maximum angle
                rotatingUp = false; // Switch direction
            }
        }
        else
        {
            // Rotate down
            currentAngle -= deltaAngle;
            if (currentAngle <= -maxAngle)
            {
                currentAngle = -maxAngle; // Clamp to the minimum angle
                rotatingUp = true; // Switch direction
            }
        }

        // Apply the rotation
        transform.rotation = initialRotation * Quaternion.Euler(0, 0, currentAngle);
    }
    public void EndGame()
    {
        timer.timerStopper = true;
        Invoke("NextGame", waitTime);
    }
    private void NextGame()
    {
        SceneRandomizer.Win = true;
    }

    public GameObject GetLaser()
    {
        return laser;
    }

    public void Reload()
    {
        Debug.Log("Triggering reload");
        isPaused = false;
    }
}