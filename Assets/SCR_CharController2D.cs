using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_CharController2D : MonoBehaviour {

    SpriteRenderer sprRenderer;
    public float maxSpeed = 10f;
    public float jumpForce = 5f;
    public static bool b_right = true;
    public bool b_isGrounded;
    //public GameObject groundCheck;

    public Transform bulletSpawnR;
    public Transform bulletSpawnL;
    Rigidbody2D myRB;
    Animator myAnim;

    public GameObject bulletNormal;
    public GameObject bulletFire;

    GameObject currentBullet;

    public LayerMask ground_layer;

	void Start () {

        myAnim = GetComponent<Animator>();
        sprRenderer = GetComponent<SpriteRenderer>();
        myRB = GetComponent<Rigidbody2D>();
        currentBullet = bulletNormal;
	}
	
	void FixedUpdate ()
    {
        IsGrounded();
        float move = Input.GetAxisRaw("Horizontal");
        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);

        if (move > 0 && !b_right)
            FlipSprite();
        else if (move < 0 && b_right)
            FlipSprite();


        if (myRB.velocity.y <= 0 && !b_isGrounded)
        {
            Debug.Log("Falling faster");
            myRB.gravityScale += 0.2f;
        }
        else
        {
            myRB.gravityScale = 1;
        }

       

        myAnim.SetInteger("Speed", Mathf.Abs((int)move));

        Debug.Log("GROUNDED: " + b_isGrounded);

        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.U))
        {
            UnlockHighJump();
        }

        
	}

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (b_right)
                Instantiate(currentBullet, bulletSpawnR.position, Quaternion.identity);

            else
                Instantiate(currentBullet, bulletSpawnL.position, Quaternion.identity);
        }

        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Space)) && b_isGrounded)
        {
            //myRB.gravityScale = 1;
            myRB.velocity = new Vector2(0, jumpForce);
        }
    }

    public void UnlockHighJump()
    {
        jumpForce = 7.5f;
    }

    public void UnlockFireBullets()
    {
        currentBullet = bulletFire;
    }

    private void IsGrounded()
    {
        b_isGrounded = Physics2D.OverlapCircle(new Vector2(transform.position.x + 0.08f, transform.position.y - 0.22f), 0.35f, ground_layer);
    }

    void FlipSprite()
    {
        b_right = !b_right;
        sprRenderer.flipX = !b_right;
    }
}
