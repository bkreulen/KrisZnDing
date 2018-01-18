using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.AI;

public class shoot : NetworkBehaviour {

	public GameObject effectPrefab;
	public GameObject projPrefab;
	public int projSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer) {
			return;
		}

		if (Input.GetKeyDown ("q")) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			Physics.Raycast (ray, out hit, 100);
			Vector3 target = new Vector3 (hit.point.x, 1, hit.point.z);

			CmdCast (target);

		}
			
		if (Input.GetKeyDown ("w")) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			Physics.Raycast (ray, out hit, 100);
			Vector3 target = new Vector3 (hit.point.x, 1, hit.point.z);

			Vector3 start = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
            


			start = Vector3.MoveTowards(start, target, 1);

			Vector3 dir = target - transform.position;

			CmdFire (start, target);

		}

		if (Input.GetKeyDown ("e")) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			Physics.Raycast (ray, out hit, 100);
			Vector3 target = new Vector3 (hit.point.x, 1, hit.point.z);

			transform.position = Vector3.MoveTowards (transform.position, target, 6);
			GetComponent<NavMeshAgent> ().destination = transform.position;
		}
		
	}

	[Command]
	void CmdCast (Vector3 target)  {
		
		GameObject effect = Instantiate (effectPrefab, target, Quaternion.LookRotation(target - transform.position));

		NetworkServer.Spawn (effect);

		Destroy (effect, 10.0f);
	}

	[Command]
	void CmdFire (Vector3 start, Vector3 target) {

		GameObject effect = Instantiate (projPrefab, start	, Quaternion.LookRotation(target - transform.position));

		Vector3 dir = target - start;
        dir.Normalize();
		effect.GetComponent<Rigidbody> ().velocity = dir * projSpeed;

		NetworkServer.Spawn (effect);

		Destroy (effect, 2.0f);
	}
		
}
