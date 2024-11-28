using UnityEngine;

public class SpotPlayerController : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Horizontal movement using A/D or Left/Right arrows
        float move = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * move * speed * Time.deltaTime);
    }
}
