using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody2D rb;

  //  public Animator anim;

    public int tocDo = 2;

    public float traiPhai;

    public bool isFacingRight = true;
    void Xoaynguoi (){
    //   Console.WriteLine($"{traiphai}");
 transform.localScale = new Vector3(-1*transform.localScale.x, 1, 1);
 isFacingRight = !isFacingRight;
    }

    void Update()
    {
        traiPhai = Input.GetAxisRaw("Horizontal"); // A = -1, 0, D = 1 
        rb.velocity = new Vector2(tocDo * traiPhai, rb.velocity.y);

        if( transform.localScale.x==1 && traiPhai==-1)
        {
           Xoaynguoi();
        }
        if(transform.localScale.x==-1 && traiPhai ==1)
        {
            Xoaynguoi();
        }
        // Animation
       // anim.SetFloat("dichuyen", Mathf.Abs(traiPhai));
    }
}
