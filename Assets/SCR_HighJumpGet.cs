using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_HighJumpGet : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<SCR_CharController2D>().UnlockHighJump();
            Debug.Log("HIGH JUMP UNLOCKED");
            Destroy(gameObject);
        }
    }
}
