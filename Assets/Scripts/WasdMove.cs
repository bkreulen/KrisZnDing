using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

//TODO make re-bindable

public class WasdMove : NetworkBehaviour {

    NavMeshAgent agent;
    Vector3 mov;
    float step;
    float up;
    float down;
    float left;
    float right;
    
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        step = 2;
	}
	
	void Update () {
		if (!isLocalPlayer)
        {
            return;
        }

        //up
        if (Input.GetKey(KeyCode.W))
        {
            up = step;
        }
        else
        {
            up = 0;
        }

        //down
        if (Input.GetKey(KeyCode.S))
        {
            down = step; 
        }
        else
        {
            down = 0;
        }

        //left
        if (Input.GetKey(KeyCode.A))
        {
            left = step; 
        }
        else
        {
            left = 0;
        }

        //right
        if (Input.GetKey(KeyCode.D))
        {
            right = step;
        }
        else
        {
            right = 0;
        }

        agent.destination = new Vector3(transform.position.x - left + right, transform.position.y, transform.position.z + up - down);


    }
}
