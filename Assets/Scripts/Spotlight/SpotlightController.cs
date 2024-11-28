using UnityEngine;

public class SpotlightController : MonoBehaviour
{
    public float moveSpeed = 3f; // Speed of the spotlight
    public float range = 4f; // Horizontal range from the center

    private float startPosition;

    void Start()
    {
        startPosition = transform.position.x;
    }

    void Update()
    {
        // Move spotlight back and forth
        float offset = Mathf.PingPong(Time.time * moveSpeed, range * 2) - range;
        transform.position = new Vector3(startPosition + offset, transform.position.y, transform.position.z);
    }
}
