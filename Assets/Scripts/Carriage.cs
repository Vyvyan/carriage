using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carriage : MonoBehaviour {

    public bool isCarriageMoving;
    public float carriageSpeed;

	// Use this for initialization
	void Start ()
    {
        isCarriageMoving = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // if our carriage is moving
		if (isCarriageMoving)
        {
            gameObject.transform.Translate(transform.forward * (carriageSpeed * Time.deltaTime));
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        // if the player stands on the carriage, it moves
        if (other.gameObject.tag == "Player Collision")
        {
            // move the cart forward
            isCarriageMoving = true;

            // parent the player to the cart, so it moves with us
            other.gameObject.transform.parent.transform.SetParent(gameObject.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // when the player leaves the carriage, it stops
        if (other.gameObject.tag == "Player Collision")
        {
            // stop the cart
            isCarriageMoving = false;

            // UNparent the player to the cart
            other.gameObject.transform.parent.transform.SetParent(null);
        }
    }
}
