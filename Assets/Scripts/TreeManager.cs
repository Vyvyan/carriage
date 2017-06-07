using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TreeManager : MonoBehaviour {

    public MegaScatterObject treeRect1A, treeRect1B, treeRect2A, treeRect2B, treeRect3A, treeRect3B;
    public GameObject treeGroup1, treeGroup2, treeGroup3;
    float lastTriggerPosTouched;
    public float[] treeGroupPositionsOnZ;

    // Use this for initialization
    void Start ()
    {
        treeGroupPositionsOnZ = new[] { treeGroup1.transform.position.z, treeGroup2.transform.position.z, treeGroup3.transform.position.z };
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void TreeSpawning(float triggerPosTouched)
    {
        // get all of the tree groups Z positions so we can then decided where to move one
        treeGroupPositionsOnZ = new[] { treeGroup1.transform.position.z, treeGroup2.transform.position.z, treeGroup3.transform.position.z };

        // The trigger we hit is in front of us
        if (triggerPosTouched > lastTriggerPosTouched)
        {
            // we need to find the farthest one back, and move it forward
            float temp = treeGroupPositionsOnZ.Min();
            // now we just compare the position of our treegroups to the highest positing of our three, to see which object has that position
            if (treeGroup1.transform.position.z == temp)
            {
                treeGroup1.transform.position = new Vector3(treeGroup1.transform.position.x, treeGroup1.transform.position.y, treeGroup1.transform.position.z + 600);
                treeRect1A.seed = Random.Range(1, 1000);
                treeRect1B.seed = Random.Range(1, 1000);
                treeRect1A.ReScatter();
                treeRect1B.ReScatter();
            }
            else if(treeGroup2.transform.position.z == temp)
            {
                treeGroup2.transform.position = new Vector3(treeGroup2.transform.position.x, treeGroup2.transform.position.y, treeGroup2.transform.position.z + 600);
                treeRect2A.seed = Random.Range(1, 1000);
                treeRect2B.seed = Random.Range(1, 1000);
                treeRect2A.ReScatter();
                treeRect2B.ReScatter();
            }
            else
            {
                treeGroup3.transform.position = new Vector3(treeGroup3.transform.position.x, treeGroup3.transform.position.y, treeGroup3.transform.position.z + 600);
                treeRect3A.seed = Random.Range(1, 1000);
                treeRect3B.seed = Random.Range(1, 1000);
                treeRect3A.ReScatter();
                treeRect3B.ReScatter();
            }
        }
        // the trigger we hit is behind us
        else if (triggerPosTouched < lastTriggerPosTouched)
        {
            // make sure we don't spawn anything before the start of the map
            if (triggerPosTouched != 250)
            {
                // we need to find the one in front, and move it backwards
                float temp = treeGroupPositionsOnZ.Max();
                // now we just compare the position of our treegroups to the lowest positing of our three, to see which object has that position
                if (treeGroup1.transform.position.z == temp)
                {
                    treeGroup1.transform.position = new Vector3(treeGroup1.transform.position.x, treeGroup1.transform.position.y, treeGroup1.transform.position.z - 600);
                    treeRect1A.seed = Random.Range(1, 1000);
                    treeRect1B.seed = Random.Range(1, 1000);
                    treeRect1A.ReScatter();
                    treeRect1B.ReScatter();
                }
                else if (treeGroup2.transform.position.z == temp)
                {
                    treeGroup2.transform.position = new Vector3(treeGroup2.transform.position.x, treeGroup2.transform.position.y, treeGroup2.transform.position.z - 600);
                    treeRect2A.seed = Random.Range(1, 1000);
                    treeRect2B.seed = Random.Range(1, 1000);
                    treeRect2A.ReScatter();
                    treeRect2B.ReScatter();
                }
                else
                {
                    treeGroup3.transform.position = new Vector3(treeGroup3.transform.position.x, treeGroup3.transform.position.y, treeGroup3.transform.position.z - 600);
                    treeRect3A.seed = Random.Range(1, 1000);
                    treeRect3B.seed = Random.Range(1, 1000);
                    treeRect3A.ReScatter();
                    treeRect3B.ReScatter();
                }
            }
        }
        // the trigger we hit is the same one
        else if(triggerPosTouched == lastTriggerPosTouched)
        {
            // do nothing, why is this even here?
        }

        lastTriggerPosTouched = triggerPosTouched;
    }
}
