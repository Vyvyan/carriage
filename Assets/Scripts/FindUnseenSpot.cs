using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindUnseenSpot : MonoBehaviour {

    Transform player;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 target = new Vector3(player.position.x, gameObject.transform.position.y, player.position.z);
        transform.LookAt(target);
	}
}
