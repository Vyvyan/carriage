using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMover : MonoBehaviour {

    public GameObject spawn;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tree")
        {
            // Random position within this our spawn transform
            Vector3 rndPosWithin;
            rndPosWithin = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            rndPosWithin = spawn.transform.TransformPoint(rndPosWithin * .5f);

            // place our object in the space area
            other.transform.position = rndPosWithin;

            // raycast
            Ray rayCastMoreLikeRayCrapLOLGottem = new Ray(other.transform.position, Vector3.down);
            RaycastHit hit;

            if (Physics.Raycast(rayCastMoreLikeRayCrapLOLGottem, out hit, 10000))
            {
                if (hit.collider.tag == "Ground")
                {
                    other.transform.position = hit.point;
                }
            }
        }
    }
}
