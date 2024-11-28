using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snakebody : MonoBehaviour
{
    public Snakebody nextPart;
    public float x;
    public float y;
    private SnakeSprite sprite;

    [HideInInspector]
    public Transform _transform;

    // Start is called before the first frame update
    void Start()
    {
        sprite = this.GetComponent<SnakeSprite>();
        _transform = this.GetComponent<Transform>();
      
    }

    // Update is called once per frame
    void Update()
    {      
        
    }

    public void Move() 
    {
       
         //move snake
            _transform.position += new Vector3(x, y, 0);
        //Set direction of next part
             CheckIfOutOfBounds();
        
            if(nextPart != null)
            { 
            
            nextPart.Move();
            nextPart.GetComponent<SnakeSprite>().SetSprite(x,y);
            nextPart.x = x;
                nextPart.y = y;
            
        }
    }
        
   

    public void CheckIfOutOfBounds()
    {
        if (_transform.position.x < -7)
        {
           this.transform.position = new Vector3(8,this.transform.position.y);
        }
        if (_transform.position.x > 8)
        {
            this.transform.position = new Vector3(-7, this.transform.position.y);
        }
        if (_transform.position.y < -4)
        {
            this.transform.position = new Vector3(this.transform.position.x, 4);
        }
        if (_transform.position.y > 4)
        {
            this.transform.position = new Vector3(this.transform.position.x, -4);
        }


    }
}
