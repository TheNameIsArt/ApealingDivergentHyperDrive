using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxEffect : MonoBehaviour
{
    public Camera cam;
    public Transform followTarget;

    // Starting position for the parralax game object
    Vector2 startingPosition;

    // Start Z value of the parralax game object 
    float startingZ;

    // Distance that camera moved from the starting position of the parralax object
    Vector2 camMoveSinceStart => (Vector2)cam.transform.position - startingPosition;

    float zDistanceFromTarget => transform.position.z - followTarget.position.z;

    float clippingPlane => (cam.transform.position.z + (zDistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));

    // the further  the object from the player, the faster the parralax effect will move. Drag its Z value closer to the target to make it move slower.
    float parrallaxFactor => Mathf.Abs(zDistanceFromTarget) / (clippingPlane);

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        startingZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        // when the target moves, move the parralax object the same distance times a multiplier
        Vector2 newPosition = startingPosition + camMoveSinceStart * parrallaxFactor;

        // X/Y position changes based on target travel speed times the parralax factor, but Z stays consistent
        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
    }
}
