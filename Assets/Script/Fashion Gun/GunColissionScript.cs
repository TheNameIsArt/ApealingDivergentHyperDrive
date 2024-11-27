using Unity.VisualScripting;
using System.Timers;
using UnityEngine;

public class TriggerInteraction : MonoBehaviour
{
    public GameObject Bruce;
    public GameObject Bob;
    public Rigidbody2D Rigidbody;
    private System.Timers.Timer timer;
    // Method to call when trigger occurs

    private void Awake()
    {
        
        Rigidbody = GetComponent<Rigidbody2D>();
        Rigidbody.isKinematic = false;
        Rigidbody.simulated = true;

    }

    // Method to call when collision occurs
    public void TriggerCollisionMethod(GameObject other)
    {
        Debug.Log($"2D Collision detected with: {other.name}");
        // Add your custom logic here
        Bruce.SetActive(true);
        Bob.SetActive(false);

    }

    // Unity's built-in collision detection method for 2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody.simulated = false;
        // Call the custom method when the collision occurs
        TriggerCollisionMethod(collision.gameObject);
    }

    private void OnTimerElapsed(object sender, ElapsedEventArgs e)
    {
        
    }
}
