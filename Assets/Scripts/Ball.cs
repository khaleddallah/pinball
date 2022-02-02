using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
{

     
    public event Action OnBallLose;
    public event Action OnBallWin;

    public float stickForce = 3f;
    public float wallForce = 1f;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        var contact = collision.contacts[0];

        if (collision.gameObject.tag == "loseWall")
        {
            if(OnBallLose != null)
            {
                OnBallLose();
            }
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "plusWall")
        {   
            if(OnBallWin != null)
            {
                OnBallWin();
            }
        }
        
        if (collision.gameObject.tag == "stick")
        {
                rb.AddForce(new Vector2(contact.normal.x, contact.normal.y)*stickForce, ForceMode2D.Impulse);
        }
        else
        {   
            if(rb.velocity.x<12 && rb.velocity.x<12)
            {
                rb.AddForce(new Vector2(contact.normal.x, contact.normal.y)*wallForce, ForceMode2D.Impulse);
            }
        }
    }
}
