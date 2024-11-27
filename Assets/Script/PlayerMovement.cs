using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Experimental;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D myBody;
    private Vector2 movement;
    private Animator myAnimator;
    public LogicScript logic;

    [SerializeField] private int speed = 5;
    // Start is called before the first frame update
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        
        
    }
    
    private void OnMovement(InputValue value)
    {
        
        
     movement = value.Get<Vector2>();
       

                if (movement.x != 0 || movement.y != 0) 
                {

                    myAnimator.SetFloat("x", movement.x);
                    myAnimator.SetFloat("y", movement.y);
            

                    myAnimator.SetBool("isWalking", true);
                }
                else 
                {
                    myAnimator.SetBool("isWalking", false);
                }
        
    }

    private void FixedUpdate()
    {
        myBody.velocity = movement * speed;
        
    }
}
