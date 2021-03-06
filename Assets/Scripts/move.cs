﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;	

public class move : NetworkBehaviour {

	NavMeshAgent agent;

	void Start() {
		agent = GetComponent<NavMeshAgent>();
	}

	void Update() {

		if (!isLocalPlayer) {
			return;
		}

		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit;

			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
				agent.destination = hit.point;
			}
		}
	}
}
