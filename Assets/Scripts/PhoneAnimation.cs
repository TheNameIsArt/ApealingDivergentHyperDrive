using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneAnimation : MonoBehaviour
{
   public Animator PhoneAnimator;
   private bool animationTriggered = false; 
    void Update()
    {
        if (!animationTriggered && Input.GetKeyDown(KeyCode.Space))
        {
            animationTriggered = true;
            PhoneAnimator.Play("PhonePickUp"); //Trigger the animation
            Debug.Log("Trigger set"); // Debug statement
        }
    }
}
