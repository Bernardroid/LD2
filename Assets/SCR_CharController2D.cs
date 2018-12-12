using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_CharController2D : MonoBehaviour {

    SpriteRenderer sprRenderer;
    public float maxSpeed = 10f;
    public float jumpForce = 5f;
    bool b_right = true;
    public bool b_isGrounded;
    Rigidbody2D myRB;
    Animator myAnim;

	void Start () {

        myAnim = GetComponent<Animator>();
        sprRenderer = GetComponent<SpriteRenderer>();
        myRB = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate ()
    {
        float move = Input.GetAxisRaw("Horizontal");
        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);

        if (move > 0 && !b_right)
            FlipSprite();
        else if (move < 0 && b_right)
            FlipSprite();

        if((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Space)) && b_isGrounded)
        {
            //myRB.gravityScale = 1;
            myRB.velocity = new Vector2(0, jumpForce);
            if (myRB.velocity.y < 0)
                myRB.gravityScale = 4;
        }

        myAnim.SetInteger("Speed", Mathf.Abs((int)move));

        Debug.Log("GROUNDED: " + b_isGrounded);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Floor"))
        {
            //Debug.Log("GROUNDED");
            b_isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Floor"))
        {
            //Debug.Log("NOT GROUNDED");
            b_isGrounded = false;
        }
    }

    void FlipSprite()
    {
        b_right = !b_right;
        sprRenderer.flipX = !b_right;
    }
}
