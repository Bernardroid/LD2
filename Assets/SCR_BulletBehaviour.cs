using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_BulletBehaviour : MonoBehaviour {

    Rigidbody2D rb;
    float bulletSpeed = 450f;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(DestroyAfterSeconds(1));

        if (SCR_CharController2D.b_right)
            rb.AddForce(Vector2.right * bulletSpeed);

        else
            rb.AddForce(Vector2.left * bulletSpeed);
    }
	
    IEnumerator DestroyAfterSeconds(int _seconds)
    {
        yield return new WaitForSecondsRealtime(_seconds);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("has entered something");
        if(collision.CompareTag("Player"))
        {
            return;
        }
        Destroy(gameObject);
    }

}
