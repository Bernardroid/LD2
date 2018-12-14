using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_BossDamage : MonoBehaviour {

    public int HP = 100;
    public GameObject winnerText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            HP -= 10;
        }
    }

    // Update is called once per frame
    void Update () {

        if (HP == 0)
        {
            winnerText.SetActive(true);
            Destroy(gameObject);
        }
		
	}
}
