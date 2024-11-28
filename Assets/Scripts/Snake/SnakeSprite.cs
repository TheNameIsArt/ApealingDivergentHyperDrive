using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeSprite : MonoBehaviour
{

    private SpriteRenderer SR;
    private Snakebody body;
    public Sprite horizontal;
    public Sprite vertical;
    public Sprite HeadUp,HeadRight,HeadLeft,HeadDown;
    public Sprite TailUp,TailRight,TailLeft,TailDown;
    public Sprite TopRight, TopLeft, BottomRight, BottomLeft;
    public bool isHead;

    // Start is called before the first frame update
    public void Start()
    {
        SR = this.GetComponent<SpriteRenderer>(); 
        body = this.GetComponent<Snakebody>();
    }
    
    public void SetSprite(float priorX, float priorY)
    {
        if (isHead)
        {
            if(priorX == 1)
            {
                SR.sprite = HeadRight;
            }
            if(priorX == -1)
            {
                SR.sprite = HeadLeft;
            }
            if(priorY == -1)
            {
                SR.sprite = HeadDown;
            }
            if (priorY == 1) 
            {
                SR.sprite = HeadUp;           
            }

            return;
        }

        if(body.nextPart == null)
        {
            if(priorX == 1)
            {
                SR.sprite = TailLeft;
            }
            if (priorX == -1)
            {
                SR.sprite = TailRight;
            }
            if (priorY == 1)
            {
                SR.sprite = TailDown;
            }
            if (priorY == -1)
            {
                SR.sprite = TailUp;
            }
            return;
        }

        //Turn Left
        if(priorX != body.x || priorY != body.y)
        {
            if(body.x == -1 && priorY == -1)
            {       
                SR.sprite = BottomRight;
            }
            if (body.y == -1 && priorX == 1)
            {
                SR.sprite = TopRight;
            }
            if (body.x == 1 && priorY == 1)
            {
                SR.sprite = TopLeft;
            }
            if (body.y == 1 && priorX == -1)
            {
                SR.sprite = BottomLeft;
            }

            //Turn Right
            if (body.y == 1 && priorX == 1)
            {
                SR.sprite = BottomRight;
            }
            if (body.x == 1 && priorY == -1)
                {
                    SR.sprite = BottomLeft;
                }
            if (body.y == -1 && priorX == -1)
            {
                SR.sprite = TopLeft;
            }
            if (body.x == -1 && priorY == 1)
            {
                SR.sprite = TopRight;
            }
            return;
        }


        if(body.x != 0)
        {
            SR.sprite = horizontal;
        }
        if (body.y != 0)
        {
            SR.sprite = vertical;
        }
    }

}
