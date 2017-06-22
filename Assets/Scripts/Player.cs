using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Camera playersCamera;
    public bool isHoldingAnObject;
    GameObject heldItem;
    public GameObject objectHoldLocation;
    SpringJoint holdJoint;
    Rigidbody heldItemRB;
    // when we pick up an object, we increase its drag while we hold it. we need this variable to change it back once we drop it
    float dragOfObjectToSwitchBackToWhenDropped;
    Vector3 holdObjectLocationsStartingPosition;

	// Use this for initialization
	void Start ()
    {
        playersCamera = Camera.main;
        holdJoint = objectHoldLocation.GetComponent<SpringJoint>();
        holdObjectLocationsStartingPosition = objectHoldLocation.transform.localPosition;
	}

    // Update is called once per frame
    void Update()
    {
        ///////////
        // RAYCASTING FROM CENTER OF CAMERA
        ///////////
        Ray ray = playersCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        if (isHoldingAnObject)
        {
            heldItemRB.MovePosition(objectHoldLocation.transform.position);
            heldItemRB.MoveRotation(objectHoldLocation.transform.rotation);

            // now we ray out from camera, THROUGH our held object, to then change how close our hold objectlocation is, incase there's something in front of us
            Ray depthRay = playersCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit depthHit;

            if (Physics.Raycast(depthRay, out depthHit, 2f))
            {
                objectHoldLocation.transform.localPosition = new Vector3(objectHoldLocation.transform.localPosition.x, objectHoldLocation.transform.localPosition.y, depthHit.distance - .25f);
            }
            else
            {
                objectHoldLocation.transform.localPosition = holdObjectLocationsStartingPosition;
            }
        }

        if (Physics.Raycast(ray, out hit, 3f))
        {
            // does the object we are looking at have a resource script?
            if (hit.transform.gameObject.GetComponent<pickUppable>() != null)
            {
                if (!isHoldingAnObject)
                {
                    // are we holding down left click?
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        
                        heldItem = hit.transform.gameObject;
                        heldItemRB = heldItem.GetComponent<Rigidbody>();
                        heldItemRB.isKinematic = true;
                        //we change the layer so we can raycast through the held object, so we can then move our holdlocation by raycasting through thheld object, its complicates, ma dood
                        heldItem.layer = LayerMask.NameToLayer("Ignore Raycast");

                        /*
                        dragOfObjectToSwitchBackToWhenDropped = heldItemRB.drag;
                        heldItemRB.drag = 800;
                        heldItemRB.mass = 25;
                        
                        // CREATE A NEW SPRING WHENEVER WE PICK UP AN OBJECT
                        // get the position of the object we are picking up to revert back to after making the spring
                        Vector3 storedPOSofObjectWePickedUp = heldItem.transform.position;
                        // move held item to the hold position
                        heldItem.transform.position = objectHoldLocation.transform.position;
                        // make the spring
                        holdJoint = objectHoldLocation.gameObject.AddComponent<SpringJoint>();
                        holdJoint.connectedBody = heldItemRB;
                        holdJoint.autoConfigureConnectedAnchor = true;
                        holdJoint.anchor = Vector3.zero;
                        holdJoint.connectedAnchor = Vector3.zero;
                        holdJoint.spring = 5000;
                        holdJoint.damper = 10f;
                        holdJoint.minDistance = 0;
                        holdJoint.maxDistance = 0;
                        // put the object back where it was
                        heldItem.transform.position = storedPOSofObjectWePickedUp;

                        // setup the thing we picked up
                        heldItemRB.drag = 10;
                        */
                    }
                }
                
            }
        }

        // dropping items
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            // if we have an item to drop
            if (heldItem)
            {
                /*
                // destroy the spring
                Destroy(holdJoint);
                heldItemRB.drag = dragOfObjectToSwitchBackToWhenDropped;
                heldItemRB.mass = 1;
                heldItemRB.velocity = heldItemRB.velocity / 2;
                */

                heldItemRB.isKinematic = false;
                heldItem.layer = LayerMask.NameToLayer("Default");
                // slow the velocity of the object as we let go so its not crazy shits
                heldItemRB.velocity = heldItemRB.velocity * .30f;
                objectHoldLocation.transform.localPosition = holdObjectLocationsStartingPosition;
                heldItem = null;
            }
        }

        // if we are holding an object, then isholdinganobject is true
        isHoldingAnObject = heldItem != null;
    }
}
