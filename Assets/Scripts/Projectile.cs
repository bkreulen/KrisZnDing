using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision other) {
		Status targetStatus = other.gameObject.GetComponent<Status> ();
		if (targetStatus != null) {
			targetStatus.TakeDamage (50);
		}
		Destroy (this.gameObject);
	}
}
