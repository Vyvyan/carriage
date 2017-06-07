using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawnTrigger : MonoBehaviour {

    TreeManager treeMan;
    bool hasDoneJob;

	// Use this for initialization
	void Start ()
    {
        hasDoneJob = false;
        treeMan = GameObject.FindObjectOfType<TreeManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            treeMan.TreeSpawning(gameObject.transform.position.z);
        }
    }
}
