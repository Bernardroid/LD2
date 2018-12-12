using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_CamFollow : MonoBehaviour {

    public GameObject player;
    public float camSpeed = 2f;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z), Time.deltaTime * camSpeed);
		
	}
}
