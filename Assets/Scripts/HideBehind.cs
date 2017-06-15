using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HideBehind : MonoBehaviour {

    Transform playerTransform;
    NavMeshAgent agent;
    public GameObject unseenHelperPivot, unseenTarget;

    // Use this for initialization
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update ()
    {
        agent.SetDestination(unseenTarget.transform.position);

        gameObject.transform.LookAt(playerTransform.position);
	}
}
