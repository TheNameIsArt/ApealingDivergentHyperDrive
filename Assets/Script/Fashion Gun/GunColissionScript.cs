using Unity.VisualScripting;
using System.Timers;
using UnityEngine;


public class TriggerInteraction : MonoBehaviour
{
    public GameObject Bruce;
    public GameObject Bob;
    public GameObject Laser;
    public Rigidbody2D laserBody;

    public GunScript GunScript;

    private System.Timers.Timer collisionTimer;
    public float collisionTimeout = 5f; // Time in seconds to wait for a collision

    private bool collisionOccurred = false;

    public void Awake()
    {
        laserBody = GetComponent<Rigidbody2D>();
        laserBody.isKinematic = false;
        laserBody.simulated = true;
        GunScript = GameObject.Find("Fashion Gun Real_0").GetComponent<GunScript>();

        // Initialize the timer
        collisionTimer = new System.Timers.Timer(collisionTimeout * 1000); // Convert seconds to milliseconds
        collisionTimer.Elapsed += OnTimerElapsed;
        collisionTimer.AutoReset = false; // Only trigger once
    }

    private void OnEnable()
    {
        StartCollisionTimer();
    }

    private void OnDisable()
    {
        StopCollisionTimer();
    }

    // Start the timer
    private void StartCollisionTimer()
    {
        collisionOccurred = false;
        collisionTimer.Start();
    }

    // Stop the timer
    private void StopCollisionTimer()
    {
        collisionTimer.Stop();
    }

    // Handle when no collision occurs
    public void OnTimerElapsed(object sender, ElapsedEventArgs e)
    {
        if (!collisionOccurred)
        {
            Debug.Log("No collision detected within the timeout period.");

            HandleNoCollision();
        }
    }

    // Unity's built-in collision detection method for 2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionOccurred = true; // Mark that a collision occurred
        StopCollisionTimer(); // Stop the timer
        laserBody.simulated = false;

        // Call the custom method when the collision occurs
        TriggerCollisionMethod(collision.gameObject);
    }

    // Custom method for handling collision
    public void TriggerCollisionMethod(GameObject other)
    {
        Debug.Log($"2D Collision detected with: {other.name}");
        Bruce.SetActive(true);
        GunScript.EndGame();
        Bob.SetActive(false);
    }

    // Custom method for handling no collision
    private void HandleNoCollision()
    {
        Debug.Log("No collision logic executed. Disabling GameObject.");
        if (!Laser)
        {
            Debug.Log("No Laser found");
        }
        Laser.SetActive(false);
        GunScript.Reload(); // Disable the GameObject this script is attached to
        gameObject.SetActive(false);
    }
}
